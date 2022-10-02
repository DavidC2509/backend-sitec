using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.WarehouseProductAggregate
{
    public class AddSaleWarehouseProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int CountSell { get; set; }
        public void SetId(int id) => Id = id;
    }
}
