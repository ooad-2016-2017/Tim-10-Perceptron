using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class Customer : User
    {

        public string name { get; set; }

        public string surname { get; set; }

        public DateTime dateOfBirth { get; set; }

        public Enum gender { get; set; }

    }
}
