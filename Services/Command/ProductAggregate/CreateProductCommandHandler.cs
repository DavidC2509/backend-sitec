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
    public class CreateProductCommandHandler : BaseCommandHandler<IProductRepository, CreateProductCommand, int>
    {
        public CreateProductCommandHandler(IProductRepository repository) : base(repository)
        {
          
        }

        public async override Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = Product.CreateProduct(request.Name, request.Price,request.Descripciont,request.Status);
            _repository.Add(product);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return product.Id;

        }
    }
}
