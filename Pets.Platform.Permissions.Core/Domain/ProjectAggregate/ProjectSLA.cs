namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public class ProjectSLA : Entity<long>
    {
        public string SLAId { get; set; }

        protected ProjectSLA() { }

        public ProjectSLA(string slaId)
        {
            SLAId = slaId;
        }
    }
}
