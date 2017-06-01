using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.DTO
{
    public class AuthDTO
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string userName { get; set; }

        public string role { get; set; }

        public string userId { get; set; }
    }
}
