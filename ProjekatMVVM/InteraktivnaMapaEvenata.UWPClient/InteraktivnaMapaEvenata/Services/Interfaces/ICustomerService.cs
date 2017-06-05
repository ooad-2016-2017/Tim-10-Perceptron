using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomer(int customerId);

        Task<Customer> GetCustomer(string userId);

        Task<List<Customer>> GetCustomers();

        Task<Customer> Follow(int customerId, int ownerId);

        Task<Customer> Unfollow(int customerId, int ownerId);
    }
}
