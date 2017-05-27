using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class EventFlag : Flag
    {
        [Key]
        public int EventFlagId { get; set; }

        [Required]
        public int FlaggedEventId { get; set; }
        [ForeignKey("FlaggedEventId")]
        public Event FlaggedEvent { get; set; }
    }
}
