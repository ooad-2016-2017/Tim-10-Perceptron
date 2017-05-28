using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.UWP.Models;

namespace InteraktivnaMapaEvenata.Managers
{
    public class EventService : BaseService, IEventService
    {
        public EventService()
        {
            ServiceEndpoint = "api/event";
        }

        public Task<Event> GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEvents()
        {
            throw new NotImplementedException();
        }
    }
}
