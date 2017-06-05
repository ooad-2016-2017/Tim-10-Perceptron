using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;
using InteraktivnaMapaEvenata.Services.Interfaces;

namespace InteraktivnaMapaEvenata.Helpers
{
    public class OwnerDetailsVMFactory : IOwnerDetailsVMFactory
    {
        public OwnerDetailsVM Create(Owner owner, AuthenticationVM auth, ICustomerService customerService, INavigationService navigation)
        {
            return new OwnerDetailsVM(owner, auth, customerService, navigation);
        }
    }
}
