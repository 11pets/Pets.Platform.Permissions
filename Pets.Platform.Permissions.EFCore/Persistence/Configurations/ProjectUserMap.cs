using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;
using Pets.Platform.Permissions.Core.Domain.UserAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    public class ProjectUserMap : EntityMap<ProjectUser, long>
    {
        public override void Configure(EntityTypeBuilder<ProjectUser> builder)
        {
            builder.ToTable("projectusers");

            base.Configure(builder);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<long>("ProjectId").IsRequired();

            builder.Property(p => p.RoleId).IsRequired();

            builder.Property(p => p.UserId).IsRequired();

            builder.HasOne<Role>()
                   .WithMany(p => p.ProjectAssignments)
                   .HasForeignKey(p => p.RoleId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
         
            builder.HasOne<User>()
                   .WithMany(p => p.ParticipatingProjects)
                   .HasForeignKey(p => p.UserId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
