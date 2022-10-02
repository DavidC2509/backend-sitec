using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public bool Status { get; set; }
    }
}
