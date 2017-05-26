using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace InteraktivnaMapaEvenata.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("LocalDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventFlag> EventFlags { get; set; }

        public DbSet<EventState> EventStates { get; set; }

        public DbSet<Flag> Flags { get; set; }

        public DbSet<FlagState> FlagStates { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Owner> OwnerFlags { get; set; }

        public DbSet<PaymentTier> PaymentTiers { get; set; }

        public DbSet<QRScanner> QRScanners { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

}



