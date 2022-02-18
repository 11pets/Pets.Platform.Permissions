using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.Core.Domain
{
    public class Resource : Entity<string>
    {
        public string Description { get; set; }

        public virtual ICollection<SLAResourceQuota> SLAResourceQuotas { get; set; }
        public virtual ICollection<ProjectResourceQuota> ProjectResourceQuotas { get; set; }
    }
}
