using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ProjectResourceQuotaMap : EntityMap<ProjectResourceQuota, long>
    {
        public override void Configure(EntityTypeBuilder<ProjectResourceQuota> builder)
        {
            builder.ToTable("projectresourcequotas");
            
            base.Configure(builder);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<long>("ProjectId")
                   .IsRequired(true);

            builder.HasOne<Resource>()
                   .WithMany(p => p.ProjectResourceQuotas)
                   .HasForeignKey(p => p.ResourceId)
                   .IsRequired(true);
        }
    }
}
