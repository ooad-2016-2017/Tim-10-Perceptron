using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Common.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public bool IsBanned { get; set; }
    }
}
