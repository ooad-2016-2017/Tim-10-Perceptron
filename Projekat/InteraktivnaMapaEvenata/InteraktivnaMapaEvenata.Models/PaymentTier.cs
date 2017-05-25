using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class PaymentTier
    {
        public ICollection<Owner> Owners { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public DateTime Duration { get; set; }
    }
}
