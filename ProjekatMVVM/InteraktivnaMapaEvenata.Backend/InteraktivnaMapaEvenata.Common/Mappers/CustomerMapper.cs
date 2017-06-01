using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace InteraktivnaMapaEvenata.Common.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDTO ToCustomerDTO(this Customer customer)
        {
            return new CustomerDTO()
            {
                Name = customer.ApplicationUser.Name,
                Surname = customer.ApplicationUser.Surname,
                Email = customer.ApplicationUser.Email,
                Username = customer.ApplicationUser.UserName,
                IsBanned = customer.ApplicationUser.IsBanned,
                Gender = customer.Gender,
                CustomerId = customer.CustomerId,
                DateOfBirth = customer.DateOfBirth,
                //FollowedOwners = customer.FollowedOwners,
                FollowedPromotions = customer.FollowedPromotions,
                FollowedEvents = customer.FollowedEvents,
                Flags = customer.Flags
            };
        }
    }
}
