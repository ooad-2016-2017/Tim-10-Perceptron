using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InteraktivnaMapaEvenata.Models.Customer;

namespace InteraktivnaMapaEvenata.Common.DTOs
{
    public class CustomerDTO : UserDTO
    {
        public int CustomerId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Genders Gender { get; set; }

        public ICollection<OwnerDTO> FollowedOwners { get; set; }

        public ICollection<Promotion> FollowedPromotions { get; set; }

        public ICollection<Event> FollowedEvents { get; set; }

        public ICollection<Customer> Friends { get; set; }

        public ICollection<Flag> Flags { get; set; }

    }
}
