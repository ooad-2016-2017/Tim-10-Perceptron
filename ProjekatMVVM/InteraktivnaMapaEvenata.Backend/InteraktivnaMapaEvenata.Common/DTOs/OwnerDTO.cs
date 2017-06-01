using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Common.DTOs
{
    public class OwnerDTO : UserDTO
    {
        public int OwnerId { get; set; }

        public string OrganizationName { get; set; }

        public List<Event> Events { get; set; }

        public int? SelectedTierId { get; set; }

        public PaymentTier SelectedTier { get; set; }

        public ICollection<Promotion> Promotions { get; set; }

        public ICollection<QRScanner> QRScanners { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
