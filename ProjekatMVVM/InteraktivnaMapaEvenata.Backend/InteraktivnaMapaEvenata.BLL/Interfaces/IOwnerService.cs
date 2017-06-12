using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.BLL.Interfaces
{
    public interface IOwnersService
    {
        OwnerDTO GetOwner(int id);

        OwnerDTO GetOwner(string id);

        List<OwnerDTO> GetOwners();

        Owner AddOwner(Owner owner);
    }
}
