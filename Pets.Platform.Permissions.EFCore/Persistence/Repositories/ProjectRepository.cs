using Microsoft.EntityFrameworkCore;
using Pets.Platform.Permissions.Core;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PermissionsDbContext _context;
        
        public IUnitOfWork UnitOfWork 
        {
            get
            {
                return _context;
            }
        }

        public ProjectRepository(PermissionsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Project Add(Project project)
        {
            return _context.Projects.Add(project).Entity;
        }

        public async Task<Project> FindAsync(long projectId)
        {
            var project = await _context
                                .Projects
                                .FirstOrDefaultAsync(p => p.Id == projectId);
            
            if(project == null)
            {
                project = _context.Projects.Local.FirstOrDefault(p => p.Id == projectId);
            }

            if(project != null)
            {
                await _context.Entry(project).Collection(p => p.Participants).LoadAsync();
                await _context.Entry(project).Collection(p => p.ProductFamilyAssignments).LoadAsync();
                await _context.Entry(project).Collection(p => p.ProjectResourceQuotas).LoadAsync();
                await _context.Entry(project).Collection(p => p.SLAs).LoadAsync();
                await _context.Entry(project).Reference(p => p.ProjectSettings).LoadAsync();
                if(project.ProjectSettings == null)
                {
                    project.InitializeProjectSettings();
                    _context.Add(project.ProjectSettings);
                }
            }

            return project;
        }

        public void Update(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
        }
    }
}
