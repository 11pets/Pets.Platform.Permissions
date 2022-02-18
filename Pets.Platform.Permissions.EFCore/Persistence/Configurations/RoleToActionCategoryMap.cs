using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class RoleToActionCategoryMap : IEntityTypeConfiguration<RoleToActionCategory>
    {
        public void Configure(EntityTypeBuilder<RoleToActionCategory> builder)
        {
            builder.ToTable("roletoactioncategories");
            builder.HasKey(prop => prop.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(p => p.ActionCategory)
                   .WithMany(p => p.RoleToActions)
                   .HasForeignKey(p => p.ActionCategoryId);

            builder.HasOne(p => p.Role)
                   .WithMany(p => p.RoleToActionCategories)
                   .HasForeignKey(p => p.RoleId);
        }
    }
}
