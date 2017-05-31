using Flurl;
using Flurl.Http;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services
{
    public class EventService : BaseService, IEventService
    {
        public override string ServiceEndpoint { get; } = "api/event";

        public EventService() { }

        public async Task<Event> GetEventById(int id)
        {
            return await ServiceEndpoint.AppendPathSegment(id)
                                        .WithOAuthBearerToken(Token)
                                        .GetJsonAsync<Event>();
        }
          
        public async Task<List<Event>> GetEvents()
        {
            return await Get<List<Event>>($"{ServiceEndpoint}");
        }

    }
}
