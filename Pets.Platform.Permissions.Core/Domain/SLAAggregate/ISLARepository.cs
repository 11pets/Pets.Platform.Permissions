namespace Pets.Platform.Permissions.Core.Domain.SLAAggregate
{
    public interface ISLARepository : IRepository<SLA>
    {
        SLA Add(SLA sla);
        void Update(SLA sla);

        Task<SLA> GetAsync(string slaId);
        Task<IEnumerable<SLA>> GetAsync(IEnumerable<string> slaIds);
    }
}
