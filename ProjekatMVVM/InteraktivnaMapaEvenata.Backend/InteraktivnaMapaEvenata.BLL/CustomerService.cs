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

        public CustomerDTO Follow(int customerId, int ownerId)
        {
            Customer customer = GetCustomerModel(customerId);
            Owner owner = _context.Owners.Where(x => x.OwnerId == ownerId).FirstOrDefault();
            if (customer.FollowedOwners.Where(x => x.OwnerId == owner.OwnerId).FirstOrDefault() != null)
                return customer.ToCustomerDTO();
            customer.FollowedOwners.Add(owner);
            _context.SaveChanges();
            return customer.ToCustomerDTO();
        }

        public CustomerDTO Unfollow(int customerId, int ownerId)
        {
            Customer customer = GetCustomerModel(customerId);
            Owner owner = _context.Owners.Where(x => x.OwnerId == ownerId).FirstOrDefault();
            customer.FollowedOwners.Remove(owner);
            owner.Followers.Remove(owner.Followers.Where(x => x.CustomerId == customerId).FirstOrDefault());
            _context.SaveChanges();
            return customer.ToCustomerDTO();
        }

        private Customer GetCustomerModel(int id)
        {
            return _context.Customers.Where(x => x.CustomerId == id)
                        .Include(x => x.ApplicationUser)
                        .Include(x => x.Events)
                        .Include(x => x.FollowedOwners)
                        .Include(x => x.FollowedPromotions)
                        .Include(x => x.Friends)
                        .FirstOrDefault();
        }

        public CustomerDTO GetCustomer(string id)
        {
            Customer query = _context.Customers.Include(x => x.ApplicationUser)
                .Where(x => x.ApplicationUser.Id == id)
                .Include(x => x.Events)
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
                .Include(x => x.Events)
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
                .Include(x => x.Events)
                .Include(x => x.FollowedOwners)
                .Include(x => x.FollowedPromotions)
                .Include(x => x.Friends)
                .ToList()
                .Select(x => x.ToCustomerDTO())
                .ToList();
        }

        public Customer AddCustomer(Customer customer)
        {
            customer = _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}
