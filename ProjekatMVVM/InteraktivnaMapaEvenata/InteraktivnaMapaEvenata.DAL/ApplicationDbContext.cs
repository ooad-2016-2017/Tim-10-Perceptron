using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;

namespace InteraktivnaMapaEvenata.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("InteractiveEventMap")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();



            //    modelBuilder.Entity<Notification>()
            //                .HasRequired(c => c.DestinationUser)
            //                .WithMany()
            //                .WillCascadeOnDelete(false);
            //    modelBuilder.Entity<Owner>()
            //        .HasRequired(c => c.SelectedTier)
            //        .WithMany(c => c.)

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventFlag> EventFlags { get; set; }

        public DbSet<EventState> EventStates { get; set; }

        public DbSet<Flag> Flags { get; set; }

        public DbSet<FlagState> FlagStates { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<OwnerFlag> OwnerFlags { get; set; }

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



