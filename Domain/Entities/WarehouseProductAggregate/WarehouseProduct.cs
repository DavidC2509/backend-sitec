using CoreDomain.Domain;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.WarehouseProductAggregate
{
    public class WarehouseProduct : BaseModel, IAggregateRoot
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public override int Id { get; protected set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public int Count { get; set; }

        /// <summary>
        /// Listado de ventan del producto del almacen
        /// </summary>
        private List<WarehouseProductSale> _warehouseProductSale;
        public IReadOnlyList<WarehouseProductSale> WarehouseProductSale => _warehouseProductSale;

        /// <summary>
        /// Constructor de clase.
        /// </summary>        
        internal WarehouseProduct(int warehouseId, int productId, int count, int id = default) : this()
        {
            Id = id;
            WarehouseId = warehouseId;
            ProductId = productId;
            Count = count;
        }

        private WarehouseProduct()
        {
            _warehouseProductSale = new List<WarehouseProductSale>();
        }



        #region Reglas de negocio

        public static WarehouseProduct CreateWarehouseProduct
        (int warehouseId, int productId, int count, int id = default)
        => new(warehouseId, productId, count, id);


        public void UpdateWarehouseProduct(int count)
        {
            Count = count;
        }


        public void AddSaleWarehoueProduct(int countSell,double priceSell)
        {
            if (Count < countSell) throw new InvalidOperationException("Cantidad a vender supera el stock"); 

            Count = Count - countSell;
            _warehouseProductSale.Add(new WarehouseProductSale(countSell, priceSell));
        }

        #endregion

    }
}
