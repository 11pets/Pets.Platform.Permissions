using Pets.Platform.Permissions.Core.Interfaces;

namespace Pets.Platform.Permissions.Core.Services;

public class DefaultPermissionsService : IPermissionsService
{
    private readonly IPermissionProvider _permissionsProvider;

    public DefaultPermissionsService(
        IPermissionProvider permissionsProvider)
    {
        _permissionsProvider = permissionsProvider;
    }
        
    public async Task<PermissionResult> CheckAsync(long userId, string action, long projectId)
    {
        var permittedActions = await _permissionsProvider.GetPermittedActions(userId, projectId);

        var hasPermission = permittedActions.Actions.Any(e => e.RequestType == action);

        return hasPermission ? PermissionResult.Grant() : PermissionResult.Reject($"Forbidden access for {action}");
    }
}