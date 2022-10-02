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
    public class UpdateCountWarehouseProductCommandHandler : BaseCommandHandler<IWarehouseProductRepository, UpdateCountWarehouseProductCommand, int>
    {
        public UpdateCountWarehouseProductCommandHandler(IWarehouseProductRepository repository) : base(repository)
        {

        }

        public async override Task<int> Handle(UpdateCountWarehouseProductCommand request, CancellationToken cancellationToken)
        {

            var warehouseProduct = await _repository.FindByIdAsync(request.Id);
            warehouseProduct.UpdateWarehouseProduct(request.Count);
            _repository.Update(warehouseProduct);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return warehouseProduct.Id;

        }
    }
}
