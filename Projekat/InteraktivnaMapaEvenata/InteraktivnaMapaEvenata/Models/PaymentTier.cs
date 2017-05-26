using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class PaymentTier
    {
        public ICollection<Owner> Owners { get; set; }
        
        public double Price { get; set; }
        
        public string Description { get; set; }
        
        public string Label { get; set; }
        
        public DateTime Duration { get; set; }
    }
}
