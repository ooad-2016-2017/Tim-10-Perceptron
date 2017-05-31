using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.BLL.Interfaces
{
    public interface IEventService
    {
        ICollection<Event> GetEvents();

        Event GetEventById(int id);

        Event AddEvent(Event eventObj);

        Event Update(Event eventObj);
    }
}
