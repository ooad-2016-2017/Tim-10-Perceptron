using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class Tag
    {
        public String Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
