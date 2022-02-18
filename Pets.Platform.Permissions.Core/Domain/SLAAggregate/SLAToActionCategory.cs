namespace Pets.Platform.Permissions.Core.Domain.SLAAggregate
{
    public class SLAToActionCategory
    {
        public long Id { get; set; }
        
        public long ActionCategoryId { get; set; }

        protected SLAToActionCategory()
        {

        }

        public SLAToActionCategory(long actionCategoryId)
        {
            ActionCategoryId = actionCategoryId;
        }
    }
}
