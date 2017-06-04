using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;

namespace InteraktivnaMapaEvenata.Helpers
{
    public interface IEventVMFactory
    {
        EventVM Create(Event evnt, AuthenticationVM authenticationVM, IEventService eventService, INavigationService navigation);
    }
}