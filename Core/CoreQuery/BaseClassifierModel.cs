using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreQuery
{
    /// <summary>
    /// Clase base para los modelos de clasificadores
    /// </summary>
    public abstract class BaseClassifierModel 
    {
        protected BaseClassifierModel()
        {
        }


        /// <summary>
        /// Id del clasificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del clasificador
        /// </summary>
        public string Name { get; set; }

    }
}
