using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.Models;

namespace InteraktivnaMapaEvenata.BLL
{
    public class UserService : IUserService
    {
        ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
