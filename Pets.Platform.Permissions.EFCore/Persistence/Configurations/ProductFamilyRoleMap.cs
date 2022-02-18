using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ProductFamilyRoleMap : EntityMap<ProductFamilyRole, long>
    {
        public override void Configure(EntityTypeBuilder<ProductFamilyRole> builder)
        {
            builder.ToTable("productfamilyroles");
            base.Configure(builder);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.ProductFamily)
                   .WithMany(p => p.AllowedRoles)
                   .HasForeignKey(p => p.ProductFamilyId);

            builder.HasOne(p => p.Role)
                   .WithMany(p => p.ProductFamilyRoles)
                   .HasForeignKey(p => p.RoleId);

        }
    }
}
