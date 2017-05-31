using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Customer
    {
        public enum Genders { Male, Female, Unspecified }

        public int CustomerId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Genders Gender { get; set; }

        public ICollection<Owner> FollowedOwners { get; set; }

        public ICollection<Promotion> FollowedPromotions { get; set; }

        public ICollection<Event> FollowedEvents { get; set; }

        public ICollection<Customer> Friends { get; set; }

        public ICollection<Flag> Flags { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
