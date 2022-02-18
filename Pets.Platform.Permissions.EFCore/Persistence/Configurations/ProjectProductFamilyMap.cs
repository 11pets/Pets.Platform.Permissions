using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    public class ProjectProductFamilyMap : EntityMap<ProjectProductFamily, long>
    {
        public override void Configure(EntityTypeBuilder<ProjectProductFamily> builder)
        {
            builder.ToTable("projectproductfamilies");
            base.Configure(builder);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<long>("ProjectId").IsRequired(true);

            builder.HasOne<ProductFamily>()
                   .WithMany(p => p.Projects)
                   .HasForeignKey(p => p.ProductFamilyId);

        }
    }
}
