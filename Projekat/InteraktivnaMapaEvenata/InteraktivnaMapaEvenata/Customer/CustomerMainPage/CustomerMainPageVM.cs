using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Customer.CustomerMainPage
{
    class CustomerMainPageVM
    {

        public UWP.Models.Customer Customer { get; set; }
        public List<UWP.Models.Event> Events { get; set; }

        public CustomerMainPageVM()
        {
            
        }

    }
}
