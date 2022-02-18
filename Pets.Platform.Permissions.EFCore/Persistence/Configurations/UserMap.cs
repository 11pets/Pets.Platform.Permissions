using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain.UserAggregate;
using Pets.Platform.Permissions.EFCore.Persistence.ValueConverters;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.IdentityGuid)
                   .IsRequired(true);

            var participatingProjectsNavigation = builder.Metadata.FindNavigation(nameof(User.ParticipatingProjects));
            participatingProjectsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var ownedProjectsNavigation = builder.Metadata.FindNavigation(nameof(User.OwnedProjects));
            ownedProjectsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(p => p.UserSettings, mp =>
            {
                mp.ToTable("usersettings");
                var converter = new JsonValueConverter<UserSettingValues>();
                mp.Property(p => p.Values)
                  .HasConversion(converter);
                mp.Property(p => p.Values).Metadata.SetValueConverter(converter);
                mp.Property(p => p.Values).Metadata.SetValueComparer(new JsonValueComparer<UserSettingValues>());
            });
        }
    }
}
