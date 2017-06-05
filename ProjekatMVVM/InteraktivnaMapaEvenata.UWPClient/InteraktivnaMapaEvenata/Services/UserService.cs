using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using InteraktivnaMapaEvenata.Validation;
using InteraktivnaMapaEvenata.DTO;

namespace InteraktivnaMapaEvenata.Services
{
    public class UserService : BaseService, IUserService
    {
        public override string ServiceEndpoint { get { return "/api/Account"; } }

        public async Task<User> GetUser(string userId) { return await Endpoint.AppendPathSegment("UserInfo").WithOAuthBearerToken(Token).GetJsonAsync<User>(); }

        public Task<Customer> RegisterCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Owner> RegisterOwner(Owner owner)
        {
            throw new NotImplementedException();
        }

        public async Task<User> RegisterUser(User user)
        {
            try
            {
                return await Endpoint.AppendPathSegment("customer")
                    .PostJsonAsync(user)
                    .ReceiveJson<User>();
            }
            catch(FlurlHttpException e)
            {
                if (e.Call.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new EntityValidationException(FromJson<EntityValidationErrorDTO>(e.Call.ErrorResponseBody));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
