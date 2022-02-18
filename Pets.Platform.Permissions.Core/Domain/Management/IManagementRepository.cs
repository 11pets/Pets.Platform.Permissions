namespace Pets.Platform.Permissions.Core.Domain.Management
{
    public interface IManagementRepository
    {
        IUnitOfWork UnitOfWork { get; }

        ProductFamily Add(ProductFamily productFamily);
        
        Task<ProductFamily> FindProductFamilyAsync(string productFamilyId);

        Task<IEnumerable<Action>> GetRoleActionsAsync(long roleId);
        
        Task<IEnumerable<ActionCategory>> GetRoleActionCategoriesAsync(int roleId);
    }
}
