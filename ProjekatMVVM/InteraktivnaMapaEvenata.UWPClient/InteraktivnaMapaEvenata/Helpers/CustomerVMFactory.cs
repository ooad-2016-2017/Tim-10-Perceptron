using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Helpers
{
    public class EventVMFactory : IEventVMFactory
    {
        public EventVM Create(Event evnt,
            AuthenticationVM authenticationVM,
            IEventService eventService,
            INavigationService navigation)
        {
            return new EventVM(evnt, authenticationVM, eventService, navigation);
        }
    }
}
