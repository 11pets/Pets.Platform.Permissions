using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class UIMenuMap : IEntityTypeConfiguration<UIMenu>
    {
        public void Configure(EntityTypeBuilder<UIMenu> builder)
        {
            builder.ToTable("uimenus");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.ParentModule)
                   .WithMany(p => p.UIMenus)
                   .HasForeignKey(p => p.ParentModuleId)
                   .IsRequired(true);

            builder.HasOne(p => p.UIModule)
                   .WithMany(p => p.AssignedToMenus)
                   .HasForeignKey(p => p.UIModuleId)
                   .IsRequired(false);

            builder.HasOne(p => p.Parent)
                   .WithMany(p => p.MenuItems)
                   .HasForeignKey(p => p.ParentId);
        }
    }
}
