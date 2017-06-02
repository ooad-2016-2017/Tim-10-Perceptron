using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services.Interfaces
{
    public interface IOwnerService : ITokenBearer
    {
        Task<Owner> GetOwner(int ownerId);

        Task<Owner> GetOwner(string id);

        Task<List<Owner>> GetOwners();
    }
}
