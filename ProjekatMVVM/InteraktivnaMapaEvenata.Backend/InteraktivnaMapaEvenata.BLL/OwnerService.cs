using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.Models;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.BLL.Interfaces;
using System.Data.Entity;

namespace InteraktivnaMapaEvenata.BLL
{
    public class OwnersService : IOwnersService
    {
        ApplicationDbContext _context;

        public OwnersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Owner GetOwner(int id)
        {
            return _context.Owners.Include(x => x.ApplicationUser)
                                  .Where(x => x.OwnerId == id)
                                  .Include(x => x.Notifications)
                                  .Include(x => x.Followers)
                                  .Include(x => x.Promotions)
                                  .Include(x => x.Events)
                                  .Include(x => x.QRScanners)
                                  .Include(x => x.SelectedTier)
                                  .FirstOrDefault();
        }

        public Owner GetOwner(string id)
        {
            return _context.Owners.Include(x => x.ApplicationUser)
                                  .Where(x => x.ApplicationUser.Id == id)
                                  .Include(x => x.Notifications)
                                  .Include(x => x.Followers)
                                  .Include(x => x.Promotions)
                                  .Include(x => x.Events)
                                  .Include(x => x.QRScanners)
                                  .Include(x => x.SelectedTier)
                                  .FirstOrDefault();
        }
    }
}
