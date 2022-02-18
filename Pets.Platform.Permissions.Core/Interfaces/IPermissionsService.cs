namespace Pets.Platform.Permissions.Core.Interfaces;

public interface IPermissionsService
{
    Task<PermissionResult> CheckAsync(long userId, string action, long projectId);
}