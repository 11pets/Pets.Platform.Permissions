namespace Pets.Platform.Permissions.Core.Domain
{
    public class UIModuleToAction
    {
        public long Id { get; set; }

        public long UIModuleId { get; set; }
        public virtual UIModule UIModule { get; set; }

        public long ActionId { get; set; }
        public virtual Action Action { get; set; }
    }
}
