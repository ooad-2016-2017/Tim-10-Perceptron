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
                UserId = customer.ApplicationUser.Id,
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
                FollowedEvents = customer.Events,
                Flags = customer.Flags
            };
        }

        public static Customer ToCustomer(this CustomerDTO dto)
        {
            throw new NotImplementedException();
#pragma warning disable CS0162 // Unreachable code detected
            return new Customer()
#pragma warning restore CS0162 // Unreachable code detected
            {
                //dto
            };
        }
    }
}
