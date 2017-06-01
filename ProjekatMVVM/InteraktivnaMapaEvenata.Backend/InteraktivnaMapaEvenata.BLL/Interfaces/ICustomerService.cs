using InteraktivnaMapaEvenata.Models;

namespace InteraktivnaMapaEvenata.BLL.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);

        Customer GetCustomer(string id);
    }
}