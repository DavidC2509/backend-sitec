using CoreDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.WarehouseProductAggregate
{
    public class WarehouseProductSale : BaseModel, IAggregateChild<WarehouseProduct>
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public override int Id { get; protected set; }

        /// <summary>
        /// Id de warehouseProduct
        /// </summary>
        public int WarehouseProductId { get; set; }
        public DateTime DateSell { get; set; }
        public int CountSell { get; set; }
        public double PriceSell { get; set; }


        /// <summary>
        /// Constructor de clase.
        /// </summary>        
        /// <param name="name">Identificador de dato de compañia.</param>
        /// <param name="price">Codigo de sistema.</param>

        internal WarehouseProductSale(int countSell, double priceSell, int id = default,int warehouseProductId=default)
        {
            Id = id;
            CountSell = countSell;
            PriceSell = priceSell;
            DateSell = DateTime.Now;
            WarehouseProductId = warehouseProductId;
        }
    }
}
