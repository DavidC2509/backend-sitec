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
    public class DeleteWarehouseCommandHandler : BaseCommandHandler<IWarehouseRepository, DeleteWarehouseCommand, bool>
    {
        public DeleteWarehouseCommandHandler(IWarehouseRepository repository) : base(repository)
        {

        }

        public async override Task<bool> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {

            var warehouse = await _repository.FindByIdAsync(request.Id);
            _repository.Delete(warehouse);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return true;

        }
    }
}
