using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.Core.Domain
{
    public class ProductFamily : Entity<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductFamilyRole> AllowedRoles { get; set; }
        public virtual ICollection<ProductFamilySla> AllowedSlas { get; set; }

        public virtual ICollection<ProjectProductFamily> Projects { get; set; }


        public long? GetDefaultRole()
        {
            return AllowedRoles?.FirstOrDefault(e => e.IsDefault)?.RoleId;
        }

        public string GetDefaultSLA()
        {
            return AllowedSlas?.FirstOrDefault(e => e.IsDefault)?.SLAId;
        }
    }
}
