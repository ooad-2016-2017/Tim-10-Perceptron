using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class OwnerFlag : Flag
    {
        [Key]
        public int OwnerFlagId { get; set; }

        public int? FlaggedOwnerId { get; set; }
        [ForeignKey("FlaggedOwnerId")]
        public Owner FlaggedOwner { get; set; }
    }
}
