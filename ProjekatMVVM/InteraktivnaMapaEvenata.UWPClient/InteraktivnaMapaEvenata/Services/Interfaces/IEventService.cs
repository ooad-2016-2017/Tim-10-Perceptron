using InteraktivnaMapaEvenata.UWP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services.Interfaces
{
    public interface IEventService
    {
        Task<List<Event>> GetEvents();

        Task<Event> GetEventById(int id);

        // TODO: Pass event objects instead of ids
        Task SignUpUser(int id, Customer user);

        Task SignOffUser(int id, Customer customer);

        Task<Event> AddEvent(Event _event);
    }
}
