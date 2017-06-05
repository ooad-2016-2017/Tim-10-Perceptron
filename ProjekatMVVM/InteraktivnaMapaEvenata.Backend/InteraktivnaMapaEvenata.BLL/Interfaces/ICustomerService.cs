using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Models;
using System.Collections.Generic;

namespace InteraktivnaMapaEvenata.BLL.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO GetCustomer(int id);

        CustomerDTO GetCustomer(string id);

        List<CustomerDTO> GetCustomers();

        CustomerDTO Follow(int customerId, int ownerId);

        CustomerDTO Unfollow(int customerId, int ownerId);
    }
}