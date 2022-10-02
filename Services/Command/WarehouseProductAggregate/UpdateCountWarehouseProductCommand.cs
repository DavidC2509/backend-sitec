using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.WarehouseProductAggregate
{
    public class UpdateCountWarehouseProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public void SetId(int id) => Id = id;

    }
}
