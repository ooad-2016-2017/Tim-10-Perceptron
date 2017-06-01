using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace InteraktivnaMapaEvenata.Services
{
    public class UserService : BaseService, IUserService
    {
        public override string ServiceEndpoint { get { return "/api/Account"; } }

        public async Task<User> GetUser(string userId) { return await Endpoint.AppendPathSegment("UserInfo").WithOAuthBearerToken(Token).GetJsonAsync<User>(); }
    }
}
