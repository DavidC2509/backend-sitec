using CoreCommand;
using Domain.Entities.WarehouseProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command.WarehouseProductAggregate
{
    public class AddProductByWarehouseCommandHandler : BaseCommandHandler<IWarehouseProductRepository, AddProductByWarehouseCommand, int>
    {
        public AddProductByWarehouseCommandHandler(IWarehouseProductRepository repository) : base(repository)
        {

        }

        public async override Task<int> Handle(AddProductByWarehouseCommand request, CancellationToken cancellationToken)
        {

            var warehouseProduct = WarehouseProduct.CreateWarehouseProduct(request.WarehouseId,request.ProductId,request.Count);
            _repository.Add(warehouseProduct);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return warehouseProduct.Id;

        }
    }
}
