using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteraktivnaMapaEvenata.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        public string Name { get; set; }

        
        [Required]
        public int EventStateId { get; set; }
        [ForeignKey("EventStateId")]
        public EventState EventState { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int? PromotionId { get; set; }
        [ForeignKey("PromotionId")]
        public Promotion Promotion { get; set; }

        public ICollection<Customer> Customers { get; set; }

        [Required]
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public ICollection<EventFlag> Flags { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
