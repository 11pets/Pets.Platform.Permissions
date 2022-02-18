using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    public abstract class EntityMap<T, K> : IEntityTypeConfiguration<T>
        where K : IEquatable<K>
        where T : Entity<K>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Ignore(p => p.DomainEvents);
        }
    }
}
