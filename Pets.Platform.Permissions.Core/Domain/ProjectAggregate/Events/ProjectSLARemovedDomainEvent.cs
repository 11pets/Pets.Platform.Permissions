using MediatR;

namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Events
{
    public class ProjectSLARemovedDomainEvent : INotification
    {
        public Project Project { get; }
        public string SLAId { get; }

        public ProjectSLARemovedDomainEvent(Project project, string slaId)
        {
            Project = project;
            SLAId = slaId;
        }
    }
}
