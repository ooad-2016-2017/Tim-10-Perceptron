using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
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

        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            try
            {
                return await Endpoint.AppendPathSegment("customer")
                    .PostJsonAsync(customer)
                    .ReceiveJson<Customer>();
            }
            catch (FlurlHttpException e)
            {
                if (e.Call.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new EntityValidationException(FromJson<EntityValidationError>(e.Call.ErrorResponseBody));
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Owner> RegisterOwner(Owner owner)
        {
            try
            {
                return await Endpoint.AppendPathSegment("owner")
                    .PostJsonAsync(owner)
                    .ReceiveJson<Owner>();
            }
            catch (FlurlHttpException e)
            {
                if (e.Call.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new EntityValidationException(FromJson<EntityValidationError>(e.Call.ErrorResponseBody));
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<User> RegisterUser(User user)
        {
            try
            {
                return await Endpoint.AppendPathSegment("user")
                    .PostJsonAsync(user)
                    .ReceiveJson<User>();
            }
            catch(FlurlHttpException e)
            {
                if (e.Call.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new EntityValidationException(FromJson<EntityValidationError>(e.Call.ErrorResponseBody));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
