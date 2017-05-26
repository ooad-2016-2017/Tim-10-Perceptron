using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class FlagState
    {
        [Key]
        public int FlagStateId { get; set; }

        public String Description { get; set; }
    }
}
