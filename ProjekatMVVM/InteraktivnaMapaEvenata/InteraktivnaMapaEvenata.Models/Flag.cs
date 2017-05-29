using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        
        public int FlaggedStateId { get; set; }
        [ForeignKey("FlaggedStateId")]
        public FlagState FlagState { get; set; }
    }
}
