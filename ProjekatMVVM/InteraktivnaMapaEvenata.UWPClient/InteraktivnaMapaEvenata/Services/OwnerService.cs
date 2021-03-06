﻿using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using InteraktivnaMapaEvenata.Services;

namespace InteraktivnaMapaEvenata.Services
{
    public class OwnerService : BaseService, IOwnerService
    {
        public override string ServiceEndpoint { get { return "/api/Owners"; } }

        public async Task<Event> GetLastEvent(int ownerId) { return await WrapSecure(Endpoint.AppendPathSegment("LatestEvent").AppendPathSegment(ownerId)).GetJsonAsync<Event>(); }

        public async Task<Owner> GetOwner(string id) { return await WrapSecure(Endpoint.AppendPathSegment("/ByUser").AppendPathSegment(id)).GetJsonAsync<Owner>(); }

        public async Task<Owner> GetOwner(int ownerId) { return await WrapSecure(Endpoint.AppendPathSegment(ownerId)).GetJsonAsync<Owner>(); }

        public async Task<List<Owner>> GetOwners() { return await SecureUri.GetJsonAsync<List<Owner>>(); }
    }
}
