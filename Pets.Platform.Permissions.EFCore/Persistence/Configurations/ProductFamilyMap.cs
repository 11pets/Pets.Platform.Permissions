using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ProductFamilyMap : IEntityTypeConfiguration<ProductFamily>
    {
        public void Configure(EntityTypeBuilder<ProductFamily> builder)
        {
            builder.ToTable("productfamilies");
            builder.HasKey(p => p.Id);
        }
    }
}
