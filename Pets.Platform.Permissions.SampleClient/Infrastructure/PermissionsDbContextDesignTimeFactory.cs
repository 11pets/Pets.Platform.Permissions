using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pets.Platform.Permissions.EFCore.Persistence;
using Pets.Platform.Permissions.Migrations;

namespace Pets.Platform.Permissions.SampleClient.Infrastructure;

public class PermissionsDbContextDesignTimeFactory : IDesignTimeDbContextFactory<PermissionsDbContext>
{
    public PermissionsDbContext CreateDbContext(string[] args)
    {
        var configuration = Helpers.GetConfiguration();
        var connectionString = configuration.GetConnectionString("Permissions");
            
        var optionsBuilder = new DbContextOptionsBuilder<PermissionsDbContext>();
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), cfg =>
        {
            cfg.MigrationsAssembly(typeof(PermissionMigrationsAnchor).Assembly.FullName);
        });

        return new PermissionsDbContext(optionsBuilder.Options, new NoMediator());
    }
    
    class NoMediator : IMediator
    {
        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
        {
            return Task.CompletedTask;
        }

        public Task Publish(object notification, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(default(TResponse));
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(default(object));
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return AsyncEnumerable.Empty<TResponse>();
        }

        public IAsyncEnumerable<object?> CreateStream(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            return AsyncEnumerable.Empty<object>();
        }
    }
}