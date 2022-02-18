namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public class ProjectResourceQuota : Entity<long>
    {
        public string ResourceId { get; set; }
        public decimal Value { get; set; }

        protected ProjectResourceQuota() { }


        public ProjectResourceQuota(string resourceId, decimal value)
        {
            this.ResourceId = resourceId;
            this.Value = value;
        }
    }


}
