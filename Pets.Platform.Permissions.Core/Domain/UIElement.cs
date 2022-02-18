namespace Pets.Platform.Permissions.Core.Domain
{
    public class UIElement
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long ActionCategoryId { get; set; }
        public virtual ActionCategory ActionCategory { get; set; }

        public long UIModuleId { get; set; }
        public virtual UIModule UIModule { get; set; }
    }
}
