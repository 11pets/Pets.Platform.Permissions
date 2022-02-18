using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class UIElementMap : IEntityTypeConfiguration<UIElement>
    {
        public void Configure(EntityTypeBuilder<UIElement> builder)
        {
            builder.ToTable("uielements");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.ActionCategory)
                   .WithMany(p => p.UIElements)
                   .HasForeignKey(p => p.ActionCategoryId)
                   .IsRequired(true);

            builder.HasOne(p => p.UIModule)
                   .WithMany(p => p.UIElements)
                   .HasForeignKey(p => p.UIModuleId);

        }
    }
}
