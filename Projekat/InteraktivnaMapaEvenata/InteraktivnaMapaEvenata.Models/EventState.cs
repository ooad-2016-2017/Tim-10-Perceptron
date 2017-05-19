using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveEventMap.DomainModel
{
    public class EventState
    {
        public int EventStateId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
