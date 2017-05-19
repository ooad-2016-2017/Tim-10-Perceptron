using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveEventMap.DomainModel
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public ApplicationUser DestinationUser { get; set; }

        public string Text { get; set; }

        public string LongText { get; set; }
    }
}
