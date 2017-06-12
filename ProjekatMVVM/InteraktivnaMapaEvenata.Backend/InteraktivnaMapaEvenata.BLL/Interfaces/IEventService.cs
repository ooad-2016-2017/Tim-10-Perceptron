using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.Common.DTOs;

namespace InteraktivnaMapaEvenata.BLL.Interfaces
{
    public interface IEventService
    {
        ICollection<Event> GetEvents();

        Event GetEventById(int id);

        Event AddEvent(Event eventObj);

        Event Update(Event eventObj);

        Event SignUpCustomer(int id, CustomerDTO customer);

        Event SignOffCustomer(int id, CustomerDTO customer);

        Event GetLatestEvent(int ownerId);
    }
}
