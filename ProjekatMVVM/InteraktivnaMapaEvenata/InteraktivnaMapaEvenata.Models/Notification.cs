using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public int SourceId { get; set; }
        [ForeignKey("SourceId")]
        public Owner Source { get; set; }

        [Required]
        public String DestinationUserId { get; set; }
        [ForeignKey("DestinationUserId")]
        public ApplicationUser DestinationUser { get; set; }

        public string Text { get; set; }

        public string LongText { get; set; }
    }
}
