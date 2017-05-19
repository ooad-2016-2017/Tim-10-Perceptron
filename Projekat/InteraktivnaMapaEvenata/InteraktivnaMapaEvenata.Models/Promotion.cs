using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveEventMap.DomainModel
{
    public class Promotion
    {
        public int PromotionId { get; set; }

        public int? CustomerLimit { get; set; }

        public List<Customer> Customers { get; set; }
    }
}
