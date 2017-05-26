using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;

namespace InteraktivnaMapaEvenata.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public EventState EventState { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public Promotion Promotion { get; set; }

        public ICollection<Customer> Customers;

        [Required]
        public Owner Owner { get; set; }

        [Required]
        public DbGeography Location { get; set; }

        public ICollection<EventFlag> Flags { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
