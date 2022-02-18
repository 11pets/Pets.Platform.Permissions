namespace Pets.Platform.Permissions.Core.Domain
{
    public class UIModule
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public long ActionCategoryId { get; set; }
        public virtual ActionCategory ActionCategory { get; set; }

        public UIModuleType Type { get; set; }

        public string Path { get; set; }

        public string Component { get; set; }
        public int Variant { get; set; }

        public long? ParentModuleId { get; set; }
        public virtual UIModule ParentModule { get; set; }

        public virtual ICollection<UIElement> UIElements { get; set; }
        public virtual ICollection<UIMenu> UIMenus { get; set; }
        public virtual ICollection<UIModuleToAction> Actions { get; set; }

        public virtual ICollection<UIMenu> AssignedToMenus { get; set; }

        public virtual ICollection<UIModule> ChildModules { get; set; }

    }


    public enum UIModuleType
    {
        Page,
        Container
    }

  

}
