using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Owner : ApplicationUser
    {
        public int OwnerId { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        public List<Event> Events { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
