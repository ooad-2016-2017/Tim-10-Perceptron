using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class Notification
    {
        public Owner Source { get; set; }
        
        public User DestinationUser { get; set; }

        public string Text { get; set; }

        public string LongText { get; set; }
    }
}
