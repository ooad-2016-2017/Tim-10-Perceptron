using InteraktivnaMapaEvenata.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        public override string ServiceEndpoint { get { return "/token"; } }

        public void LogIn(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
