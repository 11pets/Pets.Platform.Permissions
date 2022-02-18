using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    public class ProductFamilySlaMap : EntityMap<ProductFamilySla, long>
    {
        public override void Configure(EntityTypeBuilder<ProductFamilySla> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.ProductFamily)
                   .WithMany(p => p.AllowedSlas)
                   .HasForeignKey(p => p.ProductFamilyId);

            builder.HasOne(p => p.SLA)
                   .WithMany()
                   .HasForeignKey(p => p.SLAId);
        }
    }
}
