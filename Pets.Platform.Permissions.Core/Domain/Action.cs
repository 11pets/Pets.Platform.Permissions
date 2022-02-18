namespace Pets.Platform.Permissions.Core.Domain
{
    public class Action : Entity<long>
    {
        public long ActionCategoryId { get; set; }
        public virtual ActionCategory ActionCategory { get; set; }

        // _11pets.Api.PetListFilteredQuery
        public string RequestType { get; set; }

        public string ApiPath { get; set; }
        public string Method { get; set; }

        public string Service { get; set; }

        public virtual ICollection<UIModuleToAction> UIModuleToActions { get; set; }
    }
}
