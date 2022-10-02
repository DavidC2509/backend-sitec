using CoreDomain.Domain.Repository;
using Data.Database;
using Domain.Entities.WarehouseProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command.Repository
{
    public class WarehouseProductRepository : BaseRepository<WarehouseProduct>, IWarehouseProductRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        public WarehouseProductRepository(DataBaseContext context) : base(context)
        {
        }
        public WarehouseProduct Add(WarehouseProduct entity)
        {
            return AddAux(entity);
        }
        public WarehouseProduct Update(WarehouseProduct entity)
        {
            return UpdateAux(entity);
        }

        public void Delete(WarehouseProduct entity)
        {
            DeleteAux(entity);
        }

        public async Task<WarehouseProduct> FindByIdAsync(int id)
        {
            return await DataSet.Where(ele => ele.Id.Equals(id)).Include(ele => ele.WarehouseProductSale)
                                .SingleAsync();
        }
    }
}
