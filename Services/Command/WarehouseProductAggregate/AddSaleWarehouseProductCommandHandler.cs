using CoreCommand;
using Domain.Entities.WarehouseProductAggregate;
using Services.Query.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Command.WarehouseProductAggregate
{
    public class AddSaleWarehouseProductCommandHandler : BaseCommandHandler<IWarehouseProductRepository, AddSaleWarehouseProductCommand, int>
    {

        private readonly IProductQueryRepository _productRepository;
        public AddSaleWarehouseProductCommandHandler(IWarehouseProductRepository repository, IProductQueryRepository productRepository) : base(repository)
        {
            _productRepository = productRepository;
        }

        public async override Task<int> Handle(AddSaleWarehouseProductCommand request, CancellationToken cancellationToken)
        {

            var warehouseProduct = await _repository.FindByIdAsync(request.Id);
            var product = await _productRepository.GetProduct(warehouseProduct.ProductId);
            var priceSell = product.PriceIva * request.CountSell;
            warehouseProduct.AddSaleWarehoueProduct(request.CountSell, priceSell);
            _repository.Update(warehouseProduct);
            await _repository.UnitOfWork.SaveEntitiesAsync();
            return warehouseProduct.Id;

        }
    }
}
