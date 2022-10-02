using CoreDomain.Domain.Repository;
using System.Threading.Tasks;

namespace Domain.Entities.WarehouseProductAggregate
{
    public interface IWarehouseProductRepository : IRepository<WarehouseProduct>
    {
        public Task<WarehouseProduct> FindByIdAsync(int id);
    }
}
