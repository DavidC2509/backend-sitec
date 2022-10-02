using CoreDomain.Domain.Repository;
using Data.Database;
using Domain.Entities.WarehouseAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command.Repository
{
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        public WarehouseRepository(DataBaseContext context) : base(context)
        {
        }
        public Warehouse Add(Warehouse entity)
        {
            return AddAux(entity);
        }
        public Warehouse Update(Warehouse entity)
        {
            return UpdateAux(entity);
        }

        public void Delete(Warehouse entity)
        {
            DeleteAux(entity);
        }

        public async Task<Warehouse> FindByIdAsync(int id)
        {
            return await DataSet.Where(ele => ele.Id.Equals(id))
                                .SingleAsync();
        }
    }
}
