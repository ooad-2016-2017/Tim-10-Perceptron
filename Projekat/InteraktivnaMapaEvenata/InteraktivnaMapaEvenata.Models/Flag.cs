using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Flag
    {
        [Key]
        public int FlagId { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public Customer Customer { get; set; }

        public FlagState FlagState { get; set; }
    }
}
