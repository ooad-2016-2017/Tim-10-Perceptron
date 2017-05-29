using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for(int i = 0; i < 10; i++)
            {
                customers.Add(new UWP.Models.Customer(){
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
                Surname = "prezime2",
                OwnerId = 2
            });

            List<Event> events = new List<Event>();
            events.Add(new UWP.Models.Event()
            {
                Name = "ACA LUKAS KOD VEDE",
                Description = "ovo je opis",
                StartDate = new DateTime(2017, 3, 17),
                Owner = owners[0]
            });
            events.Add(new UWP.Models.Event()
            {
                Name = "GLASNO TIPKANJE KOD BURICA",
                Description = "ovo je opis2",
                StartDate = new DateTime(2017, 12, 12),
                Owner = owners[0]
            });
            events.Add(new UWP.Models.Event()
            {
                Name = "SPAVANJE KOD ELVIRA",
                Description = "debil",
                StartDate = new DateTime(2017, 12, 12),
                Owner = owners[0]
            });

            return Task.FromResult(events);

        }

    }
}
