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
    public class ListProductQueryHandler : BaseQueryHandler<IProductQueryRepository, ListProductQuery, IEnumerable<ProductModels>>
    {
        public ListProductQueryHandler(IProductQueryRepository repository) : base(repository)
        {
        }

        public override async Task<IEnumerable<ProductModels>> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListProduct();
        }
    }
}
