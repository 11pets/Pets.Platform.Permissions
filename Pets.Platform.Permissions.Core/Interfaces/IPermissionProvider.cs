using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;

namespace Pets.Platform.Permissions.Core.Interfaces;

public interface IPermissionProvider
{
    Task ReloadPermissions();
    Task<string[]> ReloadProjectSlas(long projectId);
    Task<UserAssignment[]> ReloadUserAssignments(long userId);
        
    void ReplaceProjectSlas(long projectId, string[] newSlas);
    void ReplaceUserProjectAssignments(long userId, UserAssignment[] newAssignments);

    Task<ActionPermissions> GetPermittedActions(long userId, long projectId);

    Task<UiPermissions> GetUiPermissions(long userId, long projectId);

}

public class ActionPermissions
{
    public ActionPermissions(IEnumerable<ActionType> actions)
    {
        Actions = actions;
    }
        
    public IEnumerable<ActionType> Actions { get; }
}

public class UiPermissions
{
    public IEnumerable<UIModule> UiModules { get; init; }
    public IEnumerable<UIElement> UiElements { get; init; }
    public IEnumerable<UIMenu> UiMenus { get; init; }
}

public class ActionType : IEquatable<ActionType>
{
    public long Id { get; set; }
    public long ActionCategoryId { get; set; }
    public string RequestType { get; set; }

    public bool Equals(ActionType other)
    {
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}

public class UserAssignment
{
    public long UserId { get; }
    public long ProjectId { get; }
    public long RoleId { get; }

    public UserAssignment(long userId, long projectId, long roleId)
    {
        UserId = userId;
        ProjectId = projectId;
        RoleId = roleId;
    }
}