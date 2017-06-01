using Flurl;
using Flurl.Http;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public override string ServiceEndpoint { get { return "api/Customers"; } }

        public async Task<Customer> GetCustomer(string id) { return await Endpoint.AppendPathSegment("ByUser").AppendPathSegment(id).WithOAuthBearerToken(Token).GetJsonAsync<Customer>(); }

        public async Task<Customer> GetCustomer(int ownerId) { return await Endpoint.AppendPathSegment(ownerId).WithOAuthBearerToken(Token).GetJsonAsync<Customer>(); }

    }
}
