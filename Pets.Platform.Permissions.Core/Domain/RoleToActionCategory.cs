namespace Pets.Platform.Permissions.Core.Domain
{
    public class RoleToActionCategory
    {
        public long Id { get; set; }
        public long ActionCategoryId { get; set; }
        public virtual ActionCategory ActionCategory { get; set; }
        
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}
