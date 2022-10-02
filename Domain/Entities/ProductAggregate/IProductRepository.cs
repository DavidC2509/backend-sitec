using CoreDomain.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductAggregate
{
    public interface IProductRepository : IRepository<Product>
    {

        public Task<Product> FindByIdAsync(int id);
       
    }
}
