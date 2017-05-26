﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class User
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }
        
        public bool IsBanned { get; set; }

        public byte[] ProfileImage { get; set; }

        public ICollection<Notification> Notifications { get; set; }       
    }
}
