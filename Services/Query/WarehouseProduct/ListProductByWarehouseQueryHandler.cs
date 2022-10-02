using CoreQuery;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Query.WarehouseProduct
{
    public class ListProductByWarehouseQueryHandler : BaseQueryHandler<IWarehouseProductQueryRepository, ListProductByWarehouseQuery, IEnumerable<WarehouseProductModel>>
    {
        public ListProductByWarehouseQueryHandler(IWarehouseProductQueryRepository repository) : base(repository)
        {
        }

        public override async Task<IEnumerable<WarehouseProductModel>> Handle(ListProductByWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListWarehouseproduct(request.WarehouseId);
        }
    }
}
