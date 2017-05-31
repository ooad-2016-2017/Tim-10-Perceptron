using InteraktivnaMapaEvenata.BLL.Interfaces;
using InteraktivnaMapaEvenata.Common.Validators;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;

namespace InteraktivnaMapaEvenata.BLL
{
    public class EventService : IEventService
    {
        ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
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

        public Event AddEvent(Event eventObj)
        {
            _context.Events.Add(eventObj);
            _context.SaveChanges();
            return eventObj;
        }

        public Event Update(Event eventObj)
        {
            Event evnt = _context.Events.Where(x => x.EventId == eventObj.EventId).FirstOrDefault();

            if (evnt == null)
                return null;

            evnt.Description = evnt.Description;
            evnt.EventState = evnt.EventState;
            evnt.EventStateId = evnt.EventStateId;
            //evnt.Flags = evnt.Flags;
            evnt.Latitude = evnt.Latitude;
            evnt.Longitude = evnt.Longitude;
            evnt.Name = evnt.Name;
            evnt.Owner = evnt.Owner;
            evnt.OwnerId = evnt.OwnerId;
            evnt.Promotion = evnt.Promotion;
            evnt.PromotionId = evnt.PromotionId;
            evnt.StartDate = evnt.StartDate;
            //evnt.Tags = evnt.Tags;

            _context.SaveChanges();

            return evnt;
        }
    }
}
