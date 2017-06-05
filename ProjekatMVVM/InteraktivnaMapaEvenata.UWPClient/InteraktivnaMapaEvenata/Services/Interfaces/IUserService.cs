using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(string userId);

        Task<User> RegisterUser(User user);

        Task<Customer> RegisterCustomer(Customer customer);

        Task<Owner> RegisterOwner(Owner owner);
    }
}
