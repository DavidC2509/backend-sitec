using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.Warehouse
{
    public interface IWarehouseQueryRepository
    {
        public Task<List<WarehouseModel>> ListWarehouse();

    }
}
