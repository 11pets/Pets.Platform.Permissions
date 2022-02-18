using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.Core.Domain
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public bool IsDefault { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<RoleToActionCategory> RoleToActionCategories { get; set; }
        public virtual ICollection<ProductFamilyRole> ProductFamilyRoles { get; set; }
        public virtual ICollection<ProjectUser> ProjectAssignments { get; set; }
    }
}
