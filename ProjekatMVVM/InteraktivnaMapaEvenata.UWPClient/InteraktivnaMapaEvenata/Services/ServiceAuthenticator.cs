using InteraktivnaMapaEvenata.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services
{
    public static class ServiceAuthenticator
    {
        public static T WithToken<T> (this T service, string token) where T : ITokenBearer
        {
            service.Token = token;
            return service;
        }
    }
}
