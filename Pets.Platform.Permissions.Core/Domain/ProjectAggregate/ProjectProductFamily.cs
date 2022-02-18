namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public class ProjectProductFamily : Entity<long>
    {

        public string ProductFamilyId { get; private set; }

        protected ProjectProductFamily() { }

        public ProjectProductFamily(string productFamilyId)
        {
            ProductFamilyId = productFamilyId;
        }
    }
}
