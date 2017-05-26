using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Owner : ApplicationUser
    {
        [Key]
        public int OwnerId { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<OwnerFlag> Flags { get; set; }

        [Required]
        public PaymentTier SelectedTier { get; set; }

        public ICollection<Customer> Followers { get; set; }

        public ICollection<Promotion> Promotions { get; set; }


        public ICollection<QRScanner> QRScanners { get; set; }
    }
}
