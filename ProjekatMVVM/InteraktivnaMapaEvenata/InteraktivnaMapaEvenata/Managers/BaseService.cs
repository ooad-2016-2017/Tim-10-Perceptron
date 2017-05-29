using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Managers
{
    public class BaseService
    {

        public string BaseUrl { get; set; }
        public virtual string ServiceEndpoint { get; set; }
        public string Endpoint { get { return BaseUrl + ServiceEndpoint; } }

        public BaseService()
        {
            BaseUrl = "http://localhost:50049/";
            ServiceEndpoint = "";
        }

    }
}
