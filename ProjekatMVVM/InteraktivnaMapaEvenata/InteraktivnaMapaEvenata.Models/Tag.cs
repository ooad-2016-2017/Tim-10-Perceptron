using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        public String Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
