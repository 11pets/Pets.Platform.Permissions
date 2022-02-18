using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Configurations
{
    internal class SLAMap : EntityMap<SLA, string>
    {
        public override void Configure(EntityTypeBuilder<SLA> builder)
        {
            builder.ToTable("slas");
            base.Configure(builder);
            builder.Property(p => p.Id).HasMaxLength(100);

            var slaActionCategoryNavigation = builder.Metadata.FindNavigation(nameof(SLA.ActionCategories));
            slaActionCategoryNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var slaResourceQuotaNavigation = builder.Metadata.FindNavigation(nameof(SLA.ResourceQuotas));
            slaResourceQuotaNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            var slaSetupStepsNavigation = builder.Metadata.FindNavigation(nameof(SLA.SetupSteps));
            slaSetupStepsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
