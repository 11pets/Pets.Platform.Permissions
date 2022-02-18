using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ActionCategoryMap : EntityMap<ActionCategory, long>
    {
        public override void Configure(EntityTypeBuilder<ActionCategory> builder)
        {
            builder.ToTable("actioncategories");
            base.Configure(builder);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
