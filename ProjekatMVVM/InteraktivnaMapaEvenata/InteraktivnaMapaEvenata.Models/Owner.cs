using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Owner
    {
        public int OwnerId { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        public List<Event> Events { get; set; }

        public ICollection<OwnerFlag> Flags { get; set; }
        
        public int? SelectedTierId { get; set; }
        [ForeignKey("SelectedTierId")]
        public PaymentTier SelectedTier { get; set; }

        public ICollection<Customer> Followers { get; set; }

        public ICollection<Promotion> Promotions { get; set; }

        public ICollection<QRScanner> QRScanners { get; set; }

        public ICollection<OwnerFlag> OwnerFlags { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
