using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.WarehouseAggregate
{
    public class DeleteWarehouseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public void SetId(int id) => Id = id;
    }
}

