﻿using Flurl;
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
        public override string ServiceEndpoint { get; } = "/api/event";

        public EventService() { }

        public async Task<Event> GetEventById(int id)
        {
            return await WrapSecure(Endpoint.AppendPathSegment(id))
                                        .WithOAuthBearerToken(Token)
                                        .GetJsonAsync<Event>();
        }

        /**
         * It is also possible to use Get<List<Event>>(ServiceEndpoint)
         * */
        public async Task<List<Event>> GetEvents()
        {
            return await SecureUri.GetJsonAsync<List<Event>>();
        }

        public async Task SignUpUser(int eventId, Customer customer)
        {
            await WrapSecure(Endpoint.AppendPathSegment($"/signupcustomer/{eventId}")).PutJsonAsync(customer);
        }

        public async Task SignOffUser(int eventId, Customer customer)
        {
            await WrapSecure(Endpoint.AppendPathSegment($"/signupcustomer/{eventId}")).PutJsonAsync(customer);
        }
    }
}