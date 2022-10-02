using CoreQuery;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Query.Warehouse
{
    public class ListWarehouseQueryHandler : BaseQueryHandler<IWarehouseQueryRepository, ListWarehouseQuery, IEnumerable<WarehouseModel>>
    {
        public ListWarehouseQueryHandler(IWarehouseQueryRepository repository) : base(repository)
        {
        }

        public override async Task<IEnumerable<WarehouseModel>> Handle(ListWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _repository.ListWarehouse();
        }
    }
}
