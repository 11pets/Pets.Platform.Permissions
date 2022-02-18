using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;
using Pets.Platform.Permissions.Core.Domain.UserAggregate;
using Pets.Platform.Permissions.EFCore.Persistence.ValueConverters;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ProjectMap : EntityMap<Project, long>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");

            base.Configure(builder);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();


            builder.Property<long?>("_ownerId")
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                   .HasColumnName("OwnerId");

            builder.HasOne<User>()
                   .WithMany(e => e.OwnedProjects)
                   .HasForeignKey("_ownerId");


            builder.OwnsOne(e => e.ProjectSettings, mp =>
            {
                mp.ToTable("projectsettings");
                var converter = new JsonValueConverter<ProjectSettingValues>();
                mp.Property(p => p.Values)
                  .HasConversion(converter);
                mp.Property(p => p.Values).Metadata.SetValueConverter(converter);
                mp.Property(p => p.Values).Metadata.SetValueComparer(new JsonValueComparer<ProjectSettingValues>());
            });
                
                


            var participantsNavigation = builder.Metadata.FindNavigation(nameof(Project.Participants));
            participantsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var slaNavigation = builder.Metadata.FindNavigation(nameof(Project.SLAs));
            slaNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var prqNavigation = builder.Metadata.FindNavigation(nameof(Project.ProjectResourceQuotas));
            prqNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var pfaNavigation = builder.Metadata.FindNavigation(nameof(Project.ProductFamilyAssignments));
            pfaNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
