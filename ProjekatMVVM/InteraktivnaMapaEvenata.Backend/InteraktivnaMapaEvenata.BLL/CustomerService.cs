using InteraktivnaMapaEvenata.BLL.Interfaces;
using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Common.Mappers;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.BLL
{
    public class CustomerService : ICustomerService
    {
        ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public CustomerDTO GetCustomer(string id)
        {
            Customer query = _context.Customers.Include(x => x.ApplicationUser)
                .Where(x => x.ApplicationUser.Id == id)
                .Include(x => x.FollowedEvents)
                .Include(x => x.FollowedOwners)
                .Include(x => x.FollowedPromotions)
                .Include(x => x.Friends)
                .FirstOrDefault();
            if (query == null)
                return null;
            else
                return query.ToCustomerDTO();
        }

        public CustomerDTO GetCustomer(int id)
        {
            Customer query = _context.Customers.Where(x => x.CustomerId == id)
                .Include(x => x.ApplicationUser)
                .Include(x => x.FollowedEvents)
                .Include(x => x.FollowedOwners)
                .Include(x => x.FollowedPromotions)
                .Include(x => x.Friends)
                .FirstOrDefault();

            if (query == null)
                return null;
            else
                return query.ToCustomerDTO();
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _context.Customers
                .Include(x => x.ApplicationUser)
                .Include(x => x.FollowedEvents)
                .Include(x => x.FollowedOwners)
                .Include(x => x.FollowedPromotions)
                .Include(x => x.Friends)
                .ToList()
                .Select(x => x.ToCustomerDTO())
                .ToList();
        }
    }
}
