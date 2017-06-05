using InteraktivnaMapaEvenata.UWP.Models;
using InteraktivnaMapaEvenata.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Helpers
{
    public interface IOwnerDetailsVMFactory
    {
        OwnerDetailsVM Create(Owner owner, INavigationService navigation);
    }
}
