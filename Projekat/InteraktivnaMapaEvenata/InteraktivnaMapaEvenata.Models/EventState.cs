using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class EventState
    {
        [Key]
        public int EventStateId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
