using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.WarehouseProduct
{
    public interface IWarehouseProductQueryRepository
    {
        public Task<List<WarehouseProductModel>> ListWarehouseproduct(int idWarehouse);

    }
}

