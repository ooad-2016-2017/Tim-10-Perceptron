﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace InteraktivnaMapaEvenata.UWP.Models
{
    public class Customer : User
    {
        public int CustomerId { get; set; }

        public enum Genders { Male, Female, Unspecified }
        
        public DateTime DateOfBirth { get; set; }

        public Genders Gender { get; set; }

        public ICollection<Owner> FollowedOwners { get; set; }

        public ICollection<Promotion> FollowedPromotions { get; set; }

        public ICollection<Event> Events { get; set; }

        public ICollection<Customer> Friends { get; set; }

        public ICollection<Flag> Flags { get; set; }

        public int GenderId { get; set; }

        public Customer()
        {
            Events = new List<Event>();
            Friends = new List<Customer>();
            Flags = new List<Flag>();
            FollowedOwners = new List<Owner>();
        }
    }
}
