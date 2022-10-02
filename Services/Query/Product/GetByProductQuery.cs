using MediatR;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.Product
{
    public class GetByProductQuery : IRequest<ProductModels>
    {
        public GetByProductQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
