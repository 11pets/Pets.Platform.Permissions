using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = Pets.Platform.Permissions.Core.Domain.Action;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class ActionMap : EntityMap<Action, long>
    {
        public override void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("actions");
            base.Configure(builder);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

        }
    }
}
