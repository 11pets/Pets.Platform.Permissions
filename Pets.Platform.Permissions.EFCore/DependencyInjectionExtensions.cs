using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pets.Platform.Permissions.Core.Interfaces;
using Pets.Platform.Permissions.EFCore.Persistence;
using Pets.Platform.Permissions.EFCore.Utilities;

namespace Pets.Platform.Permissions.EFCore;

public static class DependencyInjectionExtensions
{
    // ReSharper disable once InconsistentNaming
    public static IServiceCollection AddPermissionsEFCore(this IServiceCollection services,
        Action<DbContextOptionsBuilder> optionsAction)
    {
        services.AddDbContext<PermissionsDbContext>(options =>
        {
            optionsAction?.Invoke(options);
        });

        services.AddSingleton<IPermissionProvider, PermissionProvider>();
        services.AddSingleton<IDateTimeProvider, DefaultDateTimeProvider>();
        services.AddRepositories();

        return services;
    }
    
    private static void AddRepositories(this IServiceCollection services)
    {
        var assembly = typeof(PermissionsDbContext).Assembly;

        var query = from type in assembly.GetExportedTypes().Where(e => e.Name.EndsWith("Repository"))
            where !type.IsAbstract && !type.IsGenericTypeDefinition
            let interfaces = type.GetInterfaces()
            let matchingInterface = interfaces.FirstOrDefault()
            where matchingInterface != null
            select new { interfaces, matchingInterface, type };

        foreach (var t in query)
        {
            services.Add(
                new ServiceDescriptor(
                    serviceType: t.type, 
                    implementationType: t.type, 
                    lifetime: ServiceLifetime.Scoped));

            foreach (var i in t.interfaces)
            {
                services.Add(
                    new ServiceDescriptor(
                        serviceType: i,
                        (provider) => provider.GetService(t.type),
                        lifetime: ServiceLifetime.Scoped
                    ));
            }
        }
    }
}