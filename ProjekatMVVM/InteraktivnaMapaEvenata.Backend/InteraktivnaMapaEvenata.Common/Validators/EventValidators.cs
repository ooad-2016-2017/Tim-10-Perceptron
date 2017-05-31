using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Common.Validators
{
    public static class EventValidators
    {
        public static bool IsValid(this Event even, out List<string> errorList)
        {
            errorList = new List<string>();
            return true;
        }
    }
}
