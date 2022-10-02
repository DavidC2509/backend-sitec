using CoreQuery;
using Dapper;
using Services.Models;
using Services.Query.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Query.Repository
{
    public class WarehouseQueryRepository : BaseQueryRepository, IWarehouseQueryRepository
    {
        public WarehouseQueryRepository(string connectionString) : base(connectionString)
        {
        }

        public Task<List<WarehouseModel>> ListWarehouse()
        {
            var sql = @"SELECT nWarehouseId Id , sName Name, sPlace Place, bStatus Status  FROM fassil_test.fassil_warehouse";
            var parameters = new { };
            var values = ExecutionContext(connection =>
            {
                var returnVale = connection.Query<WarehouseModel>(sql, parameters).ToList();
                return returnVale;
            });
            return Task.FromResult(values);
        }
    }
}
