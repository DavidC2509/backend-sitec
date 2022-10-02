using CoreDomain.Domain.Repository;
using System.Threading.Tasks;

namespace Domain.Entities.WarehouseAggregate
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        public Task<Warehouse> FindByIdAsync(int id);

    }
}
