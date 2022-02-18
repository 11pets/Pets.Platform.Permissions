using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class UIModuleMap : IEntityTypeConfiguration<UIModule>
    {
        public void Configure(EntityTypeBuilder<UIModule> builder)
        {
            builder.ToTable("uimodules");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.ParentModule)
                .WithMany(p => p.ChildModules)
                .HasForeignKey(p => p.ParentModuleId)
                .IsRequired(false);

            builder.HasOne(p => p.ActionCategory)
                   .WithMany(p => p.UIModules)
                   .HasForeignKey(p => p.ActionCategoryId);
            
        }
    }
}
