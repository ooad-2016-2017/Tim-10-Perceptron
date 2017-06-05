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
        public override string ServiceEndpoint { get { return "/api/Customers"; } }

        public async Task<Customer> Follow(int customerId, int ownerId)
        {
            return await Endpoint.AppendPathSegment("/follow")
                 .AppendPathSegment($"/{customerId}")
                 .AppendPathSegment($"/{ownerId}")
                 .WithOAuthBearerToken(Token)
                 .PostAsync(null)
                 .ReceiveJson<Customer>();
        }

        public async Task<Customer> GetCustomer(string id) { return await Endpoint.AppendPathSegment("ByUser").AppendPathSegment(id).WithOAuthBearerToken(Token).GetJsonAsync<Customer>(); }

        public async Task<Customer> GetCustomer(int ownerId) { return await Endpoint.AppendPathSegment(ownerId).WithOAuthBearerToken(Token).GetJsonAsync<Customer>(); }

        public async Task<List<Customer>> GetCustomers()
        {
            return await Endpoint.WithOAuthBearerToken(Token).GetJsonAsync<List<Customer>>();
        }

        public async Task<Customer> Unfollow(int customerId, int ownerId)
        {
             return await Endpoint.AppendPathSegment("/unfollow")
                 .AppendPathSegment($"/{customerId}")
                 .AppendPathSegment($"/{ownerId}")
                 .WithOAuthBearerToken(Token)
                 .PostAsync(null)
                 .ReceiveJson<Customer>();
        }
    }
}
