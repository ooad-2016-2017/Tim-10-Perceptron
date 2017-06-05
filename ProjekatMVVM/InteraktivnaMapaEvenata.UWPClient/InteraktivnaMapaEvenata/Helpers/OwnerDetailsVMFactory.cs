using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;

namespace InteraktivnaMapaEvenata.Helpers
{
    public class OwnerDetailsVMFactory : IOwnerDetailsVMFactory
    {
        public OwnerDetailsVM Create(Owner owner, INavigationService navigation)
        {
            return new OwnerDetailsVM(owner, navigation);
        }
    }
}
