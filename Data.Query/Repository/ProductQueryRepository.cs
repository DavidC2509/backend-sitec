using CoreQuery;
using Dapper;
using Services.Models;
using Services.Query.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Query.Repository
{
    public class ProductQueryRepository : BaseQueryRepository, IProductQueryRepository
    {
        public ProductQueryRepository(string connectionString) : base(connectionString)
        {
        }

        public Task<ProductModels> GetProduct(int id)
        {
            var sql = @"SELECT nProductId Id , sName Name, sDescripcion Descripcion, nPrice Price, nPriceIva PriceIva, bStatus Status  FROM fassil_test.fassil_product where nProductId=@nId";
            var parameters = new { nId=id };
            var values = ExecutionContext(connection =>
            {
                var returnVale = connection.Query<ProductModels>(sql, parameters).SingleOrDefault();
                return returnVale;
            });
            return Task.FromResult(values);
        }

        public Task<List<ProductModels>> ListProduct()
        {
            var sql = @"SELECT nProductId Id , sName Name, sDescripcion Descripcion, nPrice Price,nPriceIva PriceIva ,bStatus Status  FROM fassil_test.fassil_product";
            var parameters = new { };
            var values = ExecutionContext(connection =>
            {
                var returnVale = connection.Query<ProductModels>(sql, parameters).ToList();
                return returnVale;
            });
            return Task.FromResult(values);
        }
    }
}
