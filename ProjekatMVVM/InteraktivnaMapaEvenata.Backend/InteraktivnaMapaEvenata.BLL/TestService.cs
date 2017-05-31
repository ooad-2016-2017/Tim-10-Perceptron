using InteraktivnaMapaEvenata.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.BLL
{
    public class TestService : ITestService
    {
        public int GetNumber()
        {
            return 2;
        }
    }
}
