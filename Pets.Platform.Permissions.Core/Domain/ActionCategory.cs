using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.Core.Domain
{
    public class ActionCategory : Entity<long>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<UIModule> UIModules { get; set; }
        public virtual ICollection<UIMenu> UIMenus { get; set; }
        public virtual ICollection<UIElement> UIElements { get; set; }

        public virtual ICollection<RoleToActionCategory> RoleToActions { get; set; }
        public virtual ICollection<SLAToActionCategory> SLAtoActionCategories { get; set; }
    }
}
