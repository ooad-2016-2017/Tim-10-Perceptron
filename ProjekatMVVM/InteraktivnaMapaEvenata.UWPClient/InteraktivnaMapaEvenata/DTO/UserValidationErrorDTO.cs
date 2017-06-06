using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.DTO
{
    public class UserValidationErrorDTO
    {
        public List<string> Name { get; set; }

        public List<string> Surname { get; set; }

        public List<string> Username { get; set; }

        public List<string> Email { get; set; }

        public List<string> Password { get; set; }
    }
}
