using Flurl.Http;
using InteraktivnaMapaEvenata.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services
{
    public class BaseService : ITokenBearer
    {
        public string Token { get; set; }

        public string BaseUrl { get; set; } = Globals.LOCAL_API;

        public virtual string ServiceEndpoint { get; } = "";

        public string Endpoint { get { return BaseUrl + ServiceEndpoint; } }

        protected Windows.Web.Http.HttpClient _httpClient = new Windows.Web.Http.HttpClient();

        public static Uri Wrap(string uri) { return new Uri(uri); }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task<T> Get<T> (string request)
        {
            var result = await _httpClient.GetAsync(Wrap(request));
            return FromJson<T>(await result.Content.ReadAsStringAsync());
        }
    }

}
