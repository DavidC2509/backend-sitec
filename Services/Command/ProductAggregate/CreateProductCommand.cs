using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Command.ProductAggregate
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Descripciont { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
    }
}
