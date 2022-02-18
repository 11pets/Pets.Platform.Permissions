using MediatR;
using Pets.Platform.Permissions.Core.Domain.Management;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;
using Pets.Platform.Permissions.Core.Exceptions;

namespace Pets.Platform.Permissions.Core.Commands;

public class CreateProject : IRequest<ProjectCreated>
{
    public long UserId { get; init; }
    public string ProductFamily { get; init; }
    public long ProjectId { get; init; }
}

public class ProjectCreated
{
    public long ProjectId { get; init; }
}

public class CreateProjectHandler : IRequestHandler<CreateProject, ProjectCreated>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IManagementRepository _managementRepository;

    public CreateProjectHandler(IProjectRepository projectRepository, IManagementRepository managementRepository)
    {
        _projectRepository = projectRepository;
        _managementRepository = managementRepository;
    }

    public async Task<ProjectCreated> Handle(CreateProject request, CancellationToken cancellationToken)
    {
        var existingProject = await _projectRepository.FindAsync(request.ProjectId);

        if (existingProject is not null)
        {
            return new ProjectCreated
            {
                ProjectId = request.ProjectId
            };
        }

        var productFamily = await _managementRepository.FindProductFamilyAsync(request.ProductFamily);

        if (productFamily is null)
        {
            throw new ProjectDomainException("Invalid product family");
        }

        var defaultRole = productFamily.AllowedRoles.FirstOrDefault(x => x.IsDefault);

        if (defaultRole is null)
        {
            throw new ProjectDomainException("Invalid product family configuration. missing default role");
        }

        var defaultSla = productFamily.AllowedSlas.FirstOrDefault(x => x.IsDefault);

        var project = new Project(request.ProjectId);
        project.AddParticipant(request.UserId, defaultRole.RoleId);
        project.AddProductFamily(productFamily.Id);

        if (defaultSla is not null)
        {
            project.AddSLA(defaultSla.SLAId);
        }

        _projectRepository.Add(project);
        var added = await _projectRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        if (!added)
        {
            throw new ProjectDomainException("Could not create project");
        }

        return new ProjectCreated()
        {
            ProjectId = project.Id
        };
    }
}