using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.ViewModels
{
    class CustomerMainPageVM : BaseVM
    {
        public UWP.Models.Customer Customer { get; set; }
        public List<UWP.Models.Event> Events { get; set; }

        public IEventService EventService { get; set; }

        public CustomerMainPageVM(IEventService EventService)
        {
            this.EventService = EventService;
        }
    }
}
