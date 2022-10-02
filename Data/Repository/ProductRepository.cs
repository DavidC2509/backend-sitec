using CoreDomain.Domain.Repository;
using Data.Database;
using Domain.Entities.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Command.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public IUnitOfWork UnitOfWork => _context;
        public ProductRepository(DataBaseContext context) : base(context)
        {
        }
        public Product Add(Product entity)
        {
            return AddAux(entity);
        }
        public Product Update(Product entity)
        {
            return UpdateAux(entity);
        }

        public void Delete(Product entity)
        {
            DeleteAux(entity);
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await DataSet.Where(ele => ele.Id.Equals(id))
                                .SingleAsync();
        }
    }
}
