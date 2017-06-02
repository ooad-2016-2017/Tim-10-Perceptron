using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteraktivnaMapaEvenata.Models;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.BLL.Interfaces;
using System.Data.Entity;
using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Common.Mappers;

namespace InteraktivnaMapaEvenata.BLL
{
    public class OwnersService : IOwnersService
    {
        ApplicationDbContext _context;

        public OwnersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public OwnerDTO GetOwner(int id)
        {
            Owner query = _context.Owners.Include(x => x.ApplicationUser)
                                  .Where(x => x.OwnerId == id)
                                  .Include(x => x.Notifications)
                                  .Include(x => x.Followers)
                                  .Include(x => x.Promotions)
                                  .Include(x => x.Events)
                                  .Include(x => x.QRScanners)
                                  .Include(x => x.SelectedTier)
                                  .FirstOrDefault();

            if (query != null)
                return query.ToOwnerDTO();
            else
                return null;
        }

        public OwnerDTO GetOwner(string id)
        {
            Owner query = _context.Owners.Include(x => x.ApplicationUser)
                                  .Where(x => x.ApplicationUser.Id == id)
                                  .Include(x => x.Notifications)
                                  .Include(x => x.Followers)
                                  .Include(x => x.Promotions)
                                  .Include(x => x.Events)
                                  .Include(x => x.QRScanners)
                                  .Include(x => x.SelectedTier)
                                  .FirstOrDefault();

            if (query != null)
                return query.ToOwnerDTO();
            else
                return null;
        }

        // TODO: Add pagination
        public List<OwnerDTO> GetOwners()
        {
            return _context.Owners.Include(x => x.ApplicationUser)
                              .Include(x => x.Notifications)
                              .Include(x => x.Followers)
                              .Include(x => x.Promotions)
                              .Include(x => x.Events)
                              .Include(x => x.QRScanners)
                              .Include(x => x.SelectedTier)
                              .ToList()
                              .Select(x => x.ToOwnerDTO())
                              .ToList();
        }
    }
}
