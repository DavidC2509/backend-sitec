using CoreQuery;
using Dapper;
using Services.Models;
using Services.Query.WarehouseProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Query.Repository
{
    public class WarehouseProductQueryRepository : BaseQueryRepository, IWarehouseProductQueryRepository
    {
        public WarehouseProductQueryRepository(string connectionString) : base(connectionString)
        {
        }

        public Task<List<WarehouseProductModel>> ListWarehouseproduct(int idWarehouse)
        {
            var sql = @"SELECT WHP.nWarehouseProductId Id, PO.sName NameProduct, PO.nPriceIva Price, WHP.nCount Count 
                        FROM fassil_test.fassil_warehouseproduct WHP 
                        join fassil_test.fassil_product PO on WHP.nProductId=PO.nProductId 
                        where WHP.nWarehouseId = @nIdWarehouse;";
            var parameters = new { nIdWarehouse = idWarehouse };
            var values = ExecutionContext(connection =>
            {
                var returnVale = connection.Query<WarehouseProductModel>(sql, parameters).ToList();
                return returnVale;
            });
            return Task.FromResult(values);
        }
    }
}
