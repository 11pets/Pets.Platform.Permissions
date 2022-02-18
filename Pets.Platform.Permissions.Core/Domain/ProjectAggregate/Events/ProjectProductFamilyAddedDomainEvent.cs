using MediatR;

namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate.Events
{
    /// <summary>
    /// Event used when a product family is added to the project
    /// </summary>
    public class ProjectProductFamilyAddedDomainEvent : INotification
    {
        public Project Project { get; }
        public string ProductFamilyId { get; }

        public ProjectProductFamilyAddedDomainEvent(Project project, string productFamilyId)
        {
            Project = project;
            ProductFamilyId = productFamilyId;
        }
    }
}