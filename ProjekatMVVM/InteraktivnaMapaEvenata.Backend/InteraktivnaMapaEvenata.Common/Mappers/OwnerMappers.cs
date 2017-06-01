using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Models;

namespace InteraktivnaMapaEvenata.Common.Mappers
{
    public static class OwnerMappers
    {
        public static OwnerDTO ToOwnerDTO(this Owner owner)
        {
            return new OwnerDTO
            {
                Name = owner.ApplicationUser.Name,
                Surname = owner.ApplicationUser.Surname,
                Email = owner.ApplicationUser.Email,
                Username = owner.ApplicationUser.UserName,
                IsBanned = owner.ApplicationUser.IsBanned,
                OwnerId = owner.OwnerId,
                OrganizationName = owner.OrganizationName,
                Events = owner.Events,
                SelectedTier = owner.SelectedTier,
                SelectedTierId = owner.SelectedTierId,
                Promotions = owner.Promotions,
                QRScanners = owner.QRScanners,
                Notifications = owner.Notifications
            };
        }
    }
}
