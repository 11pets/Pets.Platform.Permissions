using Microsoft.EntityFrameworkCore;
using Pets.Platform.Permissions.Core;
using Pets.Platform.Permissions.Core.Domain.SLAAggregate;

namespace Pets.Platform.Permissions.EFCore.Persistence.Repositories
{
    public class SLARepository : ISLARepository
    {
        private readonly PermissionsDbContext _context;

        public SLARepository(PermissionsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public SLA Add(SLA sla)
        {
            return _context.SLAs.Add(sla).Entity;
        }

        public async Task<SLA> GetAsync(string slaId)
        {
            var sla = await _context.SLAs.FirstOrDefaultAsync(s => s.Id == slaId);

            if(sla == null)
            {
                sla = _context.SLAs.Local.FirstOrDefault(p => p.Id == slaId);
            }

            if(sla != null)
            {
                await _context.Entry(sla).Collection(s => s.ActionCategories).LoadAsync();
                await _context.Entry(sla).Collection(s => s.ResourceQuotas).LoadAsync();
                await _context.Entry(sla).Collection(s => s.SetupSteps).LoadAsync();
            }

            return sla;
        }

        public async Task<IEnumerable<SLA>> GetAsync(IEnumerable<string> slaIds)
        {
            var slas = await _context.SLAs.Where(s => slaIds.Any(i => i == s.Id)).ToListAsync();

            foreach(var sla in slas)
            {
                await _context.Entry(sla).Collection(s => s.ActionCategories).LoadAsync();
                await _context.Entry(sla).Collection(s => s.ResourceQuotas).LoadAsync();
                await _context.Entry(sla).Collection(s => s.SetupSteps).LoadAsync();
            }

            return slas;
        }

        public void Update(SLA sla)
        {
            _context.Entry(sla).State = EntityState.Modified;
        }

        private async Task LoadDependencies(SLA sla)
        {
            await _context.Entry(sla).Collection(s => s.ActionCategories).LoadAsync();
            await _context.Entry(sla).Collection(s => s.ResourceQuotas).LoadAsync();
            await _context.Entry(sla).Collection(s => s.SetupSteps).LoadAsync();
        }
    }
}
