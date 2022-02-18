namespace Pets.Platform.Permissions.Core.Domain
{
    public class UIMenu
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long ActionCategoryId { get; set; }

        public UIMenuState State { get; set; }

        public UIMenuType Type { get; set; }

        public string Icon { get; set; }

        public UIIconType IconType { get; set; }

        public UIMenuPosition Position { get; set; }

        /// <summary>
        /// Points to container root module
        /// </summary>
        public long ParentModuleId { get; set; }
        public virtual UIModule ParentModule { get; set; }

        /// <summary>
        /// Points to the page referenced by this menu item
        /// </summary>
        public long? UIModuleId { get; set; }
        public virtual UIModule UIModule { get; set; }

        public string Label { get; set; }

        public int Ordering { get; set; }

        public bool IsDefault { get; set; }

        public long? ParentId { get; set; }
        public virtual UIMenu Parent { get; set; }

        public virtual ICollection<UIMenu> MenuItems { get; set; }

    }

    public enum UIMenuType
    {
        Item,
        Group,
        Heading
    }

    public enum UIMenuPosition
    {
        None,
        SideBar,
        InternalSidebar,
    }

    public enum UIMenuState
    {
        Hidden,
        Visible
    }

    public enum UIIconType
    {
        Antd,
        Fontawesome,
        Pets
    }

}
