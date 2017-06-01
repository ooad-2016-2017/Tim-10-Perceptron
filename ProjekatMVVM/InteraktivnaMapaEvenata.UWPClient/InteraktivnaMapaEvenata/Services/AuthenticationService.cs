using InteraktivnaMapaEvenata.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using InteraktivnaMapaEvenata.DTO;
using System.Net.Http;

namespace InteraktivnaMapaEvenata.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public override string ServiceEndpoint { get { return "/token"; } }

        public async Task<AuthDTO> LogIn(string username, string password)
        {
            return await $"{Endpoint}"
                //.AppendPathSegment("")
                //.SetQueryParam("grant_type", "password")
                //.SetQueryParam("username", username)
                //.SetQueryParam("password", password)
                .PostUrlEncodedAsync(new
                {
                    grant_type = "password",
                    username = username,
                    password = password
                })
                //.PostStringAsync("")
                .ReceiveJson<AuthDTO>();
        }
    }
}
