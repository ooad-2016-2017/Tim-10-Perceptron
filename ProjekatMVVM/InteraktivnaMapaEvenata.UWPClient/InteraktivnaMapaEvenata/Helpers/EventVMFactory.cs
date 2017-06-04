using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;

namespace InteraktivnaMapaEvenata.Helpers
{
    public class EventVMFactory : IEventVMFactory
    {
        public EventVMFactory() { }
        public EventVM Create(Event evnt,
            AuthenticationVM authenticationVM,
            IEventService eventService,
            INavigationService navigation)
        {
            return new EventVM(evnt, authenticationVM, eventService, navigation);
        }
    }
}
