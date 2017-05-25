using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Promotion
    {
        public int? CustomerLimit { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public Owner Owner { get; set; }

        public ICollection<QRScanner> QRScanners { get; set; }

        public String Description { get; set; }

        public String Name { get; set; }
    }
}
