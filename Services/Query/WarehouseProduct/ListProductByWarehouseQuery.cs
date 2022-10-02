using MediatR;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.WarehouseProduct
{
    public class ListProductByWarehouseQuery : IRequest<IEnumerable<WarehouseProductModel>>
    {
        public int WarehouseId { get; set; }

        public ListProductByWarehouseQuery(int warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
