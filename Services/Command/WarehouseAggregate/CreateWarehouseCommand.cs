using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.WarehouseAggregate
{
    public class CreateWarehouseCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }
    }
}
