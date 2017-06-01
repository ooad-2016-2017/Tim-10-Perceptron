using InteraktivnaMapaEvenata.BLL.Interfaces;
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

        public Customer GetCustomer(string id)
        {
            return _context.Customers.Include(x => x.ApplicationUser)
                .Where(x => x.ApplicationUser.Id == id)
                .Include(x => x.Gender)
                .Include(x => x.FollowedEvents)
                .Include(x => x.FollowedOwners)
                .Include(x => x.FollowedPromotions)
                .Include(x => x.Friends)
                .FirstOrDefault();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Where(x => x.CustomerId == id)
                .Include(x => x.ApplicationUser)
                .Include(x => x.Gender)
                .Include(x => x.FollowedEvents)
                .Include(x => x.FollowedOwners)
                .Include(x => x.FollowedPromotions)
                .Include(x => x.Friends)
                .FirstOrDefault();
        }
    }
}
