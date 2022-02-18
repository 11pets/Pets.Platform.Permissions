using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ProjectSLAMap : EntityMap<ProjectSLA,long>
    {
        public override void Configure(EntityTypeBuilder<ProjectSLA> builder)
        {
            builder.ToTable("projectslas");
            base.Configure(builder);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<long>("ProjectId")
                   .IsRequired(true);

            builder.HasOne<SLA>()
                   .WithMany()
                   .HasForeignKey(p => p.SLAId);
        }
    }
}
