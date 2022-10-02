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
    public class UpdateProductCommandHandler : BaseCommandHandler<IProductRepository, UpdateProductCommand, int>
    {
        public UpdateProductCommandHandler(IProductRepository repository) : base(repository)
        {

        }

        public async override Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByIdAsync(request.Id);
            product.UpdateProduct(request.Name, request.Price, request.Descripciont, request.Status);
            _repository.Update(product);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return product.Id;

        }
    }
}
