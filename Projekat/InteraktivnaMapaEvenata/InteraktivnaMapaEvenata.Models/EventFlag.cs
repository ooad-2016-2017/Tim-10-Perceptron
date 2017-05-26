using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class EventFlag : Flag
    {
        [Key]
        public int EventFlagId { get; set; }

        public Event FlaggedEvent { get; set; }
    }
}
