using InteraktivnaMapaEvenata.Services.Interfaces;
using System.Collections.Generic;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class CustomerMainPageVM : BaseVM
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
