using MediatR;

namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Events
{
    /// <summary>
    /// Event used when a project is created
    /// </summary>
    public class ProjectSLAAssignedDomainEvent : INotification
    {
        public Project Project { get; }
        public string SLAId { get; set; }

        public ProjectSLAAssignedDomainEvent(Project project, string slaId)
        {
            Project = project;
            SLAId = slaId;
        }
    }
}
