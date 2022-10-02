using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.WarehouseProductAggregate
{
    public class AddProductByWarehouseCommand : IRequest<int>
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Count { get; set; }
    }
}
