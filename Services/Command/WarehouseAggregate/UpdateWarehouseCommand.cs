using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.WarehouseAggregate
{
    public class UpdateWarehouseCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }

        public void SetId(int id) => Id = id;
    }
}
