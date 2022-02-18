using Microsoft.EntityFrameworkCore;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.ProjectAggregate;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;
using Pets.Platform.Permissions.Core.Domain.UserAggregate;
using Action = Pets.Platform.Permissions.Core.Domain.Action;

namespace Pets.Platform.Permissions.EFCore.Persistence
{
    public partial class PermissionsDbContext
    {
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<ActionCategory> ActionCategories { get; set; }
        public virtual DbSet<ProductFamily> ProductFamilies { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectResourceQuota> ProjectResourceQuotas { get; set; }
        public virtual DbSet<ProjectSLA> ProjectSLAs { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleToActionCategory> RoleToActionCategories { get; set; }
        public virtual DbSet<SLA> SLAs { get; set; }
        public virtual DbSet<SLAResourceQuota> SLAResourceQuotas { get; set; }
        public virtual DbSet<SLAToActionCategory> SLAToActionCategories { get; set; }
        public virtual DbSet<SLASetupStep> SLASetupSteps { get; set; }
        public virtual DbSet<UIElement> UIElements { get; set; }
        public virtual DbSet<UIMenu> UIMenus { get; set; }
        public virtual DbSet<UIModule> UIModules { get; set; }
        public virtual DbSet<UIModuleToAction> UIModuleToActions { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
