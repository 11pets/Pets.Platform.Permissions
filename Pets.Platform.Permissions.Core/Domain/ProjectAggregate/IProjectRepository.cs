namespace Pets.Platform.Permissions.Core.Domain.ProjectAggregate
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project Add(Project project);
        void Update(Project project);

        Task<Project> FindAsync(long projectId);
    }
}
