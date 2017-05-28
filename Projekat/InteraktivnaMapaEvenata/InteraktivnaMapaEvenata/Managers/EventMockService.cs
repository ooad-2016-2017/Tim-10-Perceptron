using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.UWP.Models;

namespace InteraktivnaMapaEvenata.Managers
{
    public class EventMockService : IEventService
    {
        public Task<Event> GetEventById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetEvents()
        {

            List<UWP.Models.Customer> customers = new List<UWP.Models.Customer>();
            for (int i = 0; i < 10; i++)
            {
                customers.Add(new UWP.Models.Customer()
                {
                    Name = "Vedo"
                });
            }

            List<UWP.Models.Owner> owners = new List<UWP.Models.Owner>();

            owners.Add(new UWP.Models.Owner()
            {
                OrganizationName = "Klix",
                Surname = "prezime",
                OwnerId = 1
            });

            owners.Add(new UWP.Models.Owner()
            {
                OrganizationName = "SarajevoX",
                Surname = "prezime",
                OwnerId = 2
            });

            owners.Add(new UWP.Models.Owner()
            {
                OrganizationName = "Portal",
                Surname = "prezime",
                OwnerId = 3
            });


            List<Notification> notifications = new List<Notification>();
            for (int i = 0; i < 10; i++)
            {
                notifications.Add(new Notification()
                {
                    Text = "textnotif"
                });
            }

            List<Event> events = new List<Event>();
            Promotion promotion = new Promotion
            {
                Name = "Ime promocije"
            };

            for (int i = 0; i < 1; i++)
            {
                events.Add(new Event()
                {
                    Name = "ACA LUKAS KOD VEDE",
                    Description = "ovo je opis",
                    StartDate = new DateTime(2017, 3, 17),
                    Owner = owners[0],
                    Promotion = promotion
                });
            }

            return Task.FromResult(events);
        }
    }
}
