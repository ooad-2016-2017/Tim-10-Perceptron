﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Models
{
    public class QRScanner : IdentityUser
    {
        [Required]
        Promotion CurrentPromotion { get; set; }

        [Required]
        Owner Owner { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<QRScanner> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

    }
}
