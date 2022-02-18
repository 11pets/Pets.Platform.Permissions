namespace Pets.Platform.Permissions.Core.Domain
{
    public class ProductFamilyRole : Entity<long>
    {
        public bool IsDefault { get; set; }

        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

        public string ProductFamilyId { get; set; }
        public virtual ProductFamily ProductFamily { get; set; }

    }
}
