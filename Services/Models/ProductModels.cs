using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ProductModels
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string BarCode { get; set; }
        public double Price { get; set; }
        public double PriceIva { get; set; }
        public bool Status { get; set; }
    }
}
