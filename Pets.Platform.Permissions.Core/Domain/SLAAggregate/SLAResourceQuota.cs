namespace Pets.Platform.Permissions.Core.Domain.SLAAggregate
{
    public class SLAResourceQuota
    {
        public long Id { get; set; }

        public decimal Value { get; set; }

        public string ResourceId { get; set; }

        protected SLAResourceQuota()
        {

        }

        public SLAResourceQuota(string resourceId, decimal value)
        {
            this.ResourceId = resourceId;
            this.Value = value;
        }
    }
}
