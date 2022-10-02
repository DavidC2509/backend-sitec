using CoreQuery;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Query.Product
{
    public class GetByProductQueryHandler : BaseQueryHandler<IProductQueryRepository, GetByProductQuery, ProductModels>
    {
        public GetByProductQueryHandler(IProductQueryRepository repository) : base(repository)
        {
        }

        public override async Task<ProductModels> Handle(GetByProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProduct(request.Id);
        }
    }
}