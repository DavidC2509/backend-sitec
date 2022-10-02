using MediatR;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Query.Product
{
    public class ListProductQuery : IRequest<IEnumerable<ProductModels>>
    {
    }
}
