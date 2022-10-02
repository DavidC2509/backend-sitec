using CoreDomain.Domain;
using Domain.Entities.WarehouseAggregate;
using Domain.Entities.WarehouseProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductAggregate
{
    public class Product : BaseModel, IAggregateRoot
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>

        public override int Id { get; protected set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string BarCode { get; set; }
        public double Price { get; set; }
        public double PriceIva { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// Constructor de clase.
        /// </summary>        
        /// <param name="name">Identificador de dato de compañia.</param>
        /// <param name="price">Codigo de sistema.</param>

        internal Product(string name,string descripcion, double price,bool status, int id = default) : this()
        {
            Id = id;
            Price = price;
            Name = name;
            Descripcion = descripcion;
            BarCode = Guid.NewGuid().ToString();
            PriceIva = Price + Price * 0.13;
            Status = status;
        }

        /// <summary>
        /// Constructor de clase.
        /// </summary>
        private Product()
        {
            
        }

        #region Reglas de negocio

        public static Product CreateProduct
        (string name, double price,string descripction,bool status ,int id = default)
        => new(name, descripction, price, status, id);


        public void UpdateProduct(string name, double price, string descripction, bool status)
        {
            Price = price;
            Name = name;
            Descripcion = descripction;
            PriceIva = Price + Price * 0.13;
            Status = status;
        }

        #endregion

    }
}