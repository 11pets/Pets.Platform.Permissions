using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class SLAResourceQuotaMap : IEntityTypeConfiguration<SLAResourceQuota>
    {
        public void Configure(EntityTypeBuilder<SLAResourceQuota> builder)
        {
            builder.ToTable("slaresourcequotas");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<string>("SLAId").IsRequired();

            builder.HasOne<Resource>()
                   .WithMany(p => p.SLAResourceQuotas)
                   .HasForeignKey(p => p.ResourceId)
                   .IsRequired();

            builder.HasOne<SLA>()
                   .WithMany(p => p.ResourceQuotas)
                   .HasForeignKey("SLAId");
        }
    }

    internal class SLASetupStepMap : IEntityTypeConfiguration<SLASetupStep>
    {
        public void Configure(EntityTypeBuilder<SLASetupStep> builder)
        {
            builder.ToTable("slasetupsteps");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property<string>("SLAId").IsRequired();

            builder.HasOne<SLA>()
                .WithMany(p => p.SetupSteps)
                .HasForeignKey("SLAId");

            builder.HasIndex("SLAId", "SetupStepName").IsUnique(true);
        }
    }
}
