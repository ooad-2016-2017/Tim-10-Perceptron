using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class Event
    {
        public int EventId { get; set; }
        
        public string Name { get; set; }
        
        public EventState EventState { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public Promotion Promotion { get; set; }


        public ICollection<Customer> Customers;

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        
        public Owner Owner { get; set; }
        
        //public DbGeography Location { get; set; }

        public ICollection<EventFlag> Flags { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Event()
        {
            Customers = new List<Customer>();
        }
    }
}
