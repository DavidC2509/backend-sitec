using CoreCommand;
using Domain.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command.ProductAggregate
{
    public class DeleteProductCommandHandler : BaseCommandHandler<IProductRepository, DeleteProductCommand, bool>
    {
        public DeleteProductCommandHandler(IProductRepository repository) : base(repository)
        {

        }

        public async override Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _repository.FindByIdAsync(request.Id);
            _repository.Delete(product);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return true;

        }
    }
}
