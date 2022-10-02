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
    public class CreateWarehouseCommandHandler : BaseCommandHandler<IWarehouseRepository, CreateWarehouseCommand, int>
    {
        public CreateWarehouseCommandHandler(IWarehouseRepository repository) : base(repository)
        {

        }

        public async override Task<int> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {

            var warehouse = Warehouse.CreateWarehouse(request.Name, request.Place, request.Status);
            _repository.Add(warehouse);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return warehouse.Id;

        }
    }
}
