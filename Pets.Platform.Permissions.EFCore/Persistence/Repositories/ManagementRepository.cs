using Microsoft.EntityFrameworkCore;
using Pets.Platform.Permissions.Core;
using Pets.Platform.Permissions.Core.Domain;
using Pets.Platform.Permissions.Core.Domain.Management;

namespace Pets.Platform.Permissions.EFCore.Persistence.Repositories
{
    public class ManagementRepository : IManagementRepository
    {
        private readonly PermissionsDbContext _context;
        public IUnitOfWork UnitOfWork 
        {
            get
            {
                return _context;
            }
        }

        public ManagementRepository(PermissionsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ProductFamily Add(ProductFamily productFamily)
        {
            return _context.ProductFamilies.Add(productFamily).Entity;
        }

        public async Task<ProductFamily> FindProductFamilyAsync(string productFamilyId)
        {
            var productFamily = await _context
                                      .ProductFamilies
                                      .FirstOrDefaultAsync(p => p.Id == productFamilyId);

            if(productFamily == null)
            {
                productFamily = _context.ProductFamilies.Local.FirstOrDefault(p => p.Id == productFamilyId);
            }

            if(productFamily != null)
            {
                await _context.Entry(productFamily).Collection(p => p.AllowedRoles).LoadAsync();
                await _context.Entry(productFamily).Collection(p => p.AllowedSlas).LoadAsync();
            }

            return productFamily;
                                      
        }

        public async Task<IEnumerable<Core.Domain.Action>> GetRoleActionsAsync(long roleId)
        {
            var actions = await _context.Roles
                                  .Include(p => p.RoleToActionCategories)
                                  .ThenInclude(p => p.ActionCategory)
                                  .ThenInclude(p => p.Actions)
                                  .Where(p => p.Id == roleId)
                                  .AsNoTracking()
                                  .SelectMany(r => r.RoleToActionCategories).SelectMany(a => a.ActionCategory.Actions).ToListAsync();

            return actions.AsEnumerable();
        }

        public async Task<IEnumerable<ActionCategory>> GetRoleActionCategoriesAsync(int roleId)
        {
            var actions = await _context.Roles
                                    .Include(p => p.RoleToActionCategories)
                                    .ThenInclude(p => p.ActionCategory)
                                    .Where(p => p.Id == roleId)
                                    .SelectMany(r => r.RoleToActionCategories)
                                    .Select(r => r.ActionCategory)
                                    .ToListAsync();

            foreach(var a in actions)
            {
                await _context.Entry(a).Collection(p => p.UIModules).LoadAsync();
            }

            return actions.AsEnumerable();
        }
    }
}
