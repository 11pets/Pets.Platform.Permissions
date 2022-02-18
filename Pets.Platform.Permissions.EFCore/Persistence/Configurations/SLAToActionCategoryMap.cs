using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class SLAToActionCategoryMap : IEntityTypeConfiguration<SLAToActionCategory>
    {
        public void Configure(EntityTypeBuilder<SLAToActionCategory> builder)
        {
            builder.ToTable("slatoactioncategories");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<string>("SLAId")
                   .IsRequired(true);

            builder.HasOne<SLA>()
                   .WithMany(p => p.ActionCategories)
                   .HasForeignKey("SLAId");

            builder.HasOne<ActionCategory>()
                   .WithMany(p => p.SLAtoActionCategories)
                   .HasForeignKey(p => p.ActionCategoryId);
        }
    }
}
