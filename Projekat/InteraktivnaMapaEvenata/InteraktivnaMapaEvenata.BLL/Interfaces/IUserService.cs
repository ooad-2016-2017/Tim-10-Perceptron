using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Interfaces
{
    public interface IUserService
    {
        bool AddUser(ApplicationUser user);

        bool UpdateUser(ApplicationUser user);
    }
}
