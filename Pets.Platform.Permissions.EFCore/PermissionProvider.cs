using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Interfaces;
using Pets.Platform.Permissions.EFCore.Persistence;
using Pets.Platform.Permissions.EFCore.Utilities;
using Action = Pets.Platform.Permissions.Core.Domain.Action;

namespace Pets.Platform.Permissions.EFCore;

public class PermissionProvider : IPermissionProvider
{
    private readonly DbContextOptions<PermissionsDbContext> _dbContextOptions;
    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly ConcurrentDictionary<long, Timestamped<string[]>> _projectSlas = new();

    private readonly ConcurrentDictionary<long, Timestamped<long[]>> _roleActionCategories = new();

    private readonly ConcurrentDictionary<string, Timestamped<long[]>> _slaActionCategories = new();

    private readonly ConcurrentDictionary<string, ActionType[]> _slaActions = new();
    private readonly ConcurrentDictionary<long, ActionCategory> _actionCategories = new();

    private readonly ConcurrentDictionary<long, Action> _actions = new();

    private readonly ConcurrentDictionary<long, ActionType[]> _roleActions = new();

    private readonly ConcurrentDictionary<long, Timestamped<UIModule>> _uiModules = new();

    private readonly ConcurrentDictionary<long, Timestamped<UIMenu>> _uiMenus = new();

    private readonly ConcurrentDictionary<long, Timestamped<UIElement>> _uiElements = new();

    private readonly ConcurrentDictionary<long, Timestamped<UserAssignment[]>> _userAssignments = new();

    public PermissionProvider(
        DbContextOptions<PermissionsDbContext> dbContextOptions, IDateTimeProvider dateTimeProvider)
    {
        _dbContextOptions = dbContextOptions;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task ReloadPermissions()
    {
        using (var db = new PermissionsDbContext(_dbContextOptions))
        {
            _projectSlas.Clear();
            _roleActionCategories.Clear();
            _slaActionCategories.Clear();
            _slaActions.Clear();
            _actionCategories.Clear();
            _actions.Clear();
            _roleActions.Clear();
            _uiModules.Clear();
            _uiMenus.Clear();
            _uiElements.Clear();
            _userAssignments.Clear();

            await ReloadAllActionCategories(db);
            await ReloadAllSlaActionCategories(db);
            await ReloadAllRoleActionCategories(db);
            await ReloadAllActions(db);
            await ReloadRoleActions(db);
            await ReloadUiElements(db);
            await ReloadUiMenus(db);
            await ReloadUiModules(db);
        }
    }

    public async Task<string[]> ReloadProjectSlas(long projectId)
    {
        await using var db = new PermissionsDbContext(_dbContextOptions);
        var project = await db.Projects.AsNoTracking().Include(x => x.SLAs).FirstOrDefaultAsync(x => x.Id == projectId);

        if (project is not null)
        {
            var projectSlas = project.SLAs.Select(x => x.SLAId).ToArray();

            _projectSlas.AddOrUpdate(projectId, new Timestamped<string[]>(projectSlas, _dateTimeProvider.NowUtc),
                (_, _) => new Timestamped<string[]>(projectSlas, _dateTimeProvider.NowUtc));

            return projectSlas;
        }

        return Array.Empty<string>();
    }

    public async Task<UserAssignment[]> ReloadUserAssignments(long userId)
    {
        await using var db = new PermissionsDbContext(_dbContextOptions);
        var user = await db.Users.AsNoTracking().Include(x => x.ParticipatingProjects)
            .FirstOrDefaultAsync(x => x.Id == userId);

        if (user is not null)
        {
            var assignments =
                user.ParticipatingProjects.Select(x => new UserAssignment(x.UserId, x.ProjectId, x.RoleId))
                    .ToArray();
            
            _userAssignments.AddOrUpdate(userId,
                new Timestamped<UserAssignment[]>(assignments, _dateTimeProvider.NowUtc),
                (_, _) => new Timestamped<UserAssignment[]>(assignments, _dateTimeProvider.NowUtc));
            
            return assignments;
        }

        return Array.Empty<UserAssignment>();
    }

    public void ReplaceProjectSlas(long projectId, string[] newSlas)
    {
        _projectSlas.AddOrUpdate(projectId, new Timestamped<string[]>(newSlas, _dateTimeProvider.NowUtc),
            (_, _) => new Timestamped<string[]>(newSlas, _dateTimeProvider.NowUtc));    }

    public void ReplaceUserProjectAssignments(long userId, UserAssignment[] newAssignments)
    {
        _userAssignments.AddOrUpdate(userId, new Timestamped<UserAssignment[]>(newAssignments, _dateTimeProvider.NowUtc),
            (_, _) => new Timestamped<UserAssignment[]>(newAssignments, _dateTimeProvider.NowUtc));
    }

    public async Task<ActionPermissions> GetPermittedActions(long userId, long projectId)
    {
        var userRoles = await GetUserAssignedRoles(userId, projectId);
        if (userRoles.Length == 0)
        {
            return new ActionPermissions(Enumerable.Empty<ActionType>());
        }

        var eqComparer = new ActionTypeEqualityComparer();
        var projectSlas = await GetProjectSlas(projectId);

        var projectActions = projectSlas.SelectMany(e => _slaActions[e]).Distinct(eqComparer);
        var roleActions = userRoles.SelectMany(e => _roleActions[e]).Distinct(eqComparer);

        var intersection = projectActions.Intersect(roleActions, eqComparer);

        return new ActionPermissions(intersection);
    }

    public async Task<UiPermissions> GetUiPermissions(long userId, long projectId)
    {
        var userActions = await GetPermittedActions(userId, projectId);

        var actionCategories = userActions.Actions.Select(x => x.ActionCategoryId);

        var uiModules = _uiModules.Where(x => actionCategories.Contains(x.Value.Data.ActionCategoryId))
            .Select(x => x.Value.Data);

        var uiElements = _uiElements.Where(e => actionCategories.Contains(e.Value.Data.ActionCategoryId)).Select(e => e.Value.Data);

        var uiMenus = _uiMenus.Where(x => actionCategories.Contains(x.Value.Data.ActionCategoryId))
            .Select(x => x.Value.Data);


        return new UiPermissions()
        {
            UiElements = uiElements,
            UiModules = uiModules,
            UiMenus = uiMenus
        };
    }

    private async Task<long[]> GetUserAssignedRoles(long userId, long projectId)
    {
        var assignments = await GetUserAssignments(userId);

        return assignments.Where(e => e.ProjectId == projectId).Select(e => e.RoleId).ToArray();
    }

    private async Task<UserAssignment[]> GetUserAssignments(long userId)
    {
        if (!_userAssignments.TryGetValue(userId, out var entry))
        {
            return await ReloadUserAssignments(userId);
        }

        if (entry.LastRead.AddMinutes(5) < _dateTimeProvider.NowUtc)
        {
            return await ReloadUserAssignments(userId);
        }

        return entry.Data;
    }

    private async Task<string[]> GetProjectSlas(long projectId)
    {
        if (!_projectSlas.TryGetValue(projectId, out var entry))
        {
            return await ReloadProjectSlas(projectId);
        }

        if (entry.LastRead.AddMinutes(5) < _dateTimeProvider.NowUtc)
        {
            return await ReloadProjectSlas(projectId);
        }

        return entry.Data;
    }

    #region Fill Dictionaries

    private async Task ReloadAllActionCategories(PermissionsDbContext db)
    {
        var actionCategories = await db.ActionCategories.AsNoTracking().ToListAsync();
        actionCategories.ForEach(a => _actionCategories.AddOrUpdate(a.Id, a, (c, v) => a));
    }

    private async Task ReloadAllSlaActionCategories(PermissionsDbContext db)
    {
        var actionCategories = await db.SLAs.AsNoTracking().Include(p => p.ActionCategories)
            .ToDictionaryAsync(s => s.Id, s => s.ActionCategories.Select(a => a.ActionCategoryId));


        actionCategories.Keys.ToList().ForEach(k => _slaActionCategories.AddOrUpdate(k,
            new Timestamped<long[]>(actionCategories[k].ToArray(), _dateTimeProvider.NowUtc),
            (c, v) => new Timestamped<long[]>(actionCategories[c].ToArray(), _dateTimeProvider.NowUtc)));
    }

    private async Task ReloadAllRoleActionCategories(PermissionsDbContext db)
    {
        var actionCategories = await db.RoleToActionCategories.AsNoTracking().GroupBy(s => s.RoleId)
            .ToDictionaryAsync(s => s.Key, s => s.Select(e => e.ActionCategoryId));
        actionCategories.Keys.ToList().ForEach(k => _roleActionCategories.AddOrUpdate(k,
            new Timestamped<long[]>(actionCategories[k].ToArray(), _dateTimeProvider.NowUtc),
            (c, v) => new Timestamped<long[]>(actionCategories[c].ToArray(), _dateTimeProvider.NowUtc)));
    }

    private async Task ReloadAllActions(PermissionsDbContext db)
    {
        var actions = await db.Actions.AsNoTracking().ToDictionaryAsync(x => x.Id);
        actions.Keys.ToList().ForEach(a => _actions.AddOrUpdate(a, actions[a], (k, v) => actions[k]));
    }

    private async Task ReloadRoleActions(PermissionsDbContext db)
    {
        var actions = await db.RoleToActionCategories.AsNoTracking().GroupJoin(db.Actions.AsNoTracking(),
                r => r.ActionCategoryId, a => a.ActionCategoryId, (ra, a) => new { RoleId = ra.RoleId, Actions = a })
            .ToListAsync();

        actions.ForEach(x => _roleActions.AddOrUpdate(x.RoleId, x.Actions.Select(a => new ActionType()
            {
                Id = a.Id,
                RequestType = a.RequestType,
                ActionCategoryId = a.ActionCategoryId
            }).ToArray(),
            (c, v) => x.Actions.Select(a => new ActionType()
            {
                Id = a.Id,
                RequestType = a.RequestType,
                ActionCategoryId = a.ActionCategoryId
            }).ToArray()));
    }

    private async Task ReloadUiModules(PermissionsDbContext db)
    {
        var uiModules = await db.UIModules.Include(p => p.ParentModule).Include(p => p.ChildModules).AsNoTracking()
            .ToListAsync();

        uiModules.ForEach(x =>
            _uiModules.AddOrUpdate(x.Id, new Timestamped<UIModule>(x, _dateTimeProvider.NowUtc), (c, v) => new Timestamped<UIModule>(x, _dateTimeProvider.NowUtc)));
    }

    private async Task ReloadUiMenus(PermissionsDbContext db)
    {
        var uiMenus = await db.UIMenus.Include(p => p.Parent).Include(p => p.UIModule).AsNoTracking().ToListAsync();

        uiMenus.ForEach(x =>
            _uiMenus.AddOrUpdate(x.Id, new Timestamped<UIMenu>(x, _dateTimeProvider.NowUtc), (c, v) => new Timestamped<UIMenu>(x, _dateTimeProvider.NowUtc)));
    }

    private async Task ReloadUiElements(PermissionsDbContext db)
    {
        var uiElements = await db.UIElements.AsNoTracking().ToListAsync();

        uiElements.ForEach(x =>
            _uiElements.AddOrUpdate(x.Id, new Timestamped<UIElement>(x, _dateTimeProvider.NowUtc), (c, v) => new Timestamped<UIElement>(x, _dateTimeProvider.NowUtc)));
    }

    #endregion

    private class Timestamped<T>
    {
        public T Data { get; }
        public DateTime LastRead { get; }

        public Timestamped(T data, DateTime now)
        {
            Data = data;
            LastRead = now;
        }
    }

    public class ActionTypeEqualityComparer : IEqualityComparer<ActionType>
    {
        public bool Equals(ActionType x, ActionType y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(ActionType obj)
        {
            return obj.GetHashCode();
        }
    }
}