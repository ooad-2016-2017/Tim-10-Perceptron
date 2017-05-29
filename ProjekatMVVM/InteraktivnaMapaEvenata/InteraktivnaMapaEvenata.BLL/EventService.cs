using InteraktivnaMapaEvenata.BLL.Interfaces;
using System;
using System.Collections.Generic;
using InteraktivnaMapaEvenata.Models;
using InteraktivnaMapaEvenata.DAL;
using System.Linq;

namespace InteraktivnaMapaEvenata.BLL
{
    public class EventService : IEventService
    {
        ApplicationDbContext _context;

        public EventService(ApplicationDbContext context) {
            _context = context;
        }

        public ICollection<Event> GetEvents()
        {
            return _context.Events.ToList();
        }

        public Event GetEventById(int id)
        {
            return _context.Events.Where(x => x.EventId == id).FirstOrDefault();
        }
        

    }
}
