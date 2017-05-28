using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Managers
{
    public interface IEventService
    {
        Task<List<Event>> GetEvents();

        Task<Event> GetEventById(int id);
    }
}
