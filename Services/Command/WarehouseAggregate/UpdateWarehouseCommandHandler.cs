using CoreCommand;
using Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command.WarehouseAggregate
{
    public class UpdateWarehouseCommandHandler : BaseCommandHandler<IWarehouseRepository, UpdateWarehouseCommand, int>
    {
        public UpdateWarehouseCommandHandler(IWarehouseRepository repository) : base(repository)
        {

        }

        public async override Task<int> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {

            var warehouse = await _repository.FindByIdAsync(request.Id);
            warehouse.UpdateWarehouse(request.Name, request.Place, request.Status);
            _repository.Update(warehouse);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return warehouse.Id;

        }
    }
}
