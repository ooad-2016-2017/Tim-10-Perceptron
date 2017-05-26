using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class OwnerFlag : Flag
    {
        [Key]
        public int OwnerFlagId { get; set; }

        public Owner FlaggedOwner { get; set; }
    }
}
