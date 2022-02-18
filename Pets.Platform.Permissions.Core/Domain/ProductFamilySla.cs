using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.Core.Domain
{
    public class ProductFamilySla : Entity<long>
    {
        public bool IsDefault { get; set; }
        
        public string ProductFamilyId { get; set; }
        public virtual ProductFamily ProductFamily { get; set; }

        public string SLAId { get; set; }
        public virtual SLA SLA { get; set; }
    }
}
