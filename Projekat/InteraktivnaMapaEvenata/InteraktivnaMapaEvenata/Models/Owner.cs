using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class Owner : User
    {
        public int OwnerId { get; set; }
        
        public string OrganizationName { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<OwnerFlag> Flags { get; set; }
        
        public PaymentTier SelectedTier { get; set; }

        public ICollection<Customer> Followers { get; set; }

        public ICollection<Promotion> Promotions { get; set; }


        public ICollection<QRScanner> QRScanners { get; set; }
    }
}
