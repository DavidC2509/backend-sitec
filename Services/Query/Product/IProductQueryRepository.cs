using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.Product
{
    public interface IProductQueryRepository
    {
        public Task<List<ProductModels>> ListProduct();

        public Task<ProductModels> GetProduct(int id);

    }
}
