using CoreDomain.Domain;
using Domain.Entities.ProductAggregate;
using Domain.Entities.WarehouseProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.WarehouseAggregate
{
    public class Warehouse : BaseModel, IAggregateRoot
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public override int Id { get; protected set; }

        public string Name { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }


        /// <summary>
        /// Constructor de clase.
        /// </summary>        
        internal Warehouse(string name, string place, bool status, int id = default) 
        {
            Id = id;
            Name = name;
            Place = place;
            Status = status;
        }


        #region Reglas de negocio

        public static Warehouse CreateWarehouse
        (string name, string place, bool status, int id = default)
        => new(name, place, status, id);


        public void UpdateWarehouse(string name, string place, bool status)
        {
            Name = name;
            Place = place;
            Status = status;
        }

        #endregion
    }
}
