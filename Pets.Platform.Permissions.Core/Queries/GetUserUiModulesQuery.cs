using MediatR;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Interfaces;

namespace Pets.Platform.Permissions.Core.Queries;

public class GetUserUiModules : IRequest<UserUiModules>
{
    public long UserId { get; init; }
    public long ProjectId { get; init; }
}

public class UserUiModules
{
    public IEnumerable<UIModule> Modules { get; init; }
    public IEnumerable<UIMenu> Menus { get; init; }
    public IEnumerable<UIElement> Elements { get; init; }
}

internal class GetUserUiModulesHandler : IRequestHandler<GetUserUiModules, UserUiModules>
{
    private readonly IPermissionProvider _provider;

    public GetUserUiModulesHandler(IPermissionProvider provider)
    {
        _provider = provider;
    }
    
    public async Task<UserUiModules> Handle(GetUserUiModules request, CancellationToken cancellationToken)
    {
        var uiPermissions = await _provider.GetUiPermissions(request.UserId, request.ProjectId);

        return new UserUiModules()
        {
            Modules = uiPermissions.UiModules,
            Elements = uiPermissions.UiElements,
            Menus = uiPermissions.UiMenus
        };
    }
}