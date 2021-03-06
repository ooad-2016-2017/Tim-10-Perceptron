﻿using InteraktivnaMapaEvenata.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthDTO> LogIn(string username, string password);
    }
}
