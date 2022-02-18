using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class UIModuleToActionMap : IEntityTypeConfiguration<UIModuleToAction>
    {
        public void Configure(EntityTypeBuilder<UIModuleToAction> builder)
        {
            builder.ToTable("uimoduletoactions");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.UIModule)
                   .WithMany(p => p.Actions)
                   .HasForeignKey(p => p.UIModuleId);

            builder.HasOne(p => p.Action)
                   .WithMany(p => p.UIModuleToActions)
                   .HasForeignKey(p => p.ActionId);

        }
    }
}
