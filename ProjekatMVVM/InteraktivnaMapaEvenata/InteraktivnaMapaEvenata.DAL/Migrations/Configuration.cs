namespace InteraktivnaMapaEvenata.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class DbConf : DbMigrationsConfiguration<InteraktivnaMapaEvenata.DAL.ApplicationDbContext>
    {
        public DbConf()
        {
            AutomaticMigrationsEnabled = false;
        }

        private void ClearDatabase(ApplicationDbContext context)
        {
            //Optional: disable all foreign keys (db-schema will be loosed).
            //context.Database.ExecuteSqlCommand("EXEC sp_MSforeachtable @command1 = 'ALTER TABLE ? NOCHECK CONSTRAINT all'");

            List<string> tableNames = context.Database.SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%' AND TABLE_NAME NOT LIKE 'AspNet%'").ToList();

            for (int i = 0; tableNames.Count > 0; i++)
            {
                try
                {
                    //To delete all tables and not just clean them from data, replace "DELETE FROM {0}" in "DROP TABLE {0}":
                    context.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tableNames.ElementAt(i % tableNames.Count)));
                    tableNames.RemoveAt(i % tableNames.Count);
                    i = -1; //flag: a table was removed. in the next iteration i++ will be the 0 index.
                }
                catch (System.Data.SqlClient.SqlException e)   // ignore errors as these are expected due to linked foreign key data    
                {
                    if ((i % tableNames.Count) == (tableNames.Count - 1))
                    {
                        //end of tables-list without any success to delete any table, then exit with exception:
                        throw new System.Data.DataException("Unable to clear all relevant tables in database (foriegn key constraint ?). See inner-exception for more details.", e);
                    }
                }
            }
            context.SaveChanges();
        }


        protected override void Seed(ApplicationDbContext context)
        {
            try
            {
                ClearDatabase(context);


                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                };


                const string ownerRole = "OWNER";
                const string adminRole = "ADMIN";
                const string customerRole = "CUSTOMER";
                const string qrRole = "QR";

                if (!context.Roles.Any(r => r.Name == ownerRole))
                    roleManager.Create(new IdentityRole { Name = ownerRole });
                if (!context.Roles.Any(r => r.Name == adminRole))
                    roleManager.Create(new IdentityRole { Name = adminRole });
                if (!context.Roles.Any(r => r.Name == customerRole))
                    roleManager.Create(new IdentityRole { Name = customerRole });
                if (!context.Roles.Any(r => r.Name == qrRole))
                    roleManager.Create(new IdentityRole { Name = qrRole });

                context.SaveChanges();


                PaymentTier basic = new PaymentTier
                {
                    Price = 20.0,
                    Description = "Basic",
                    Label = "Basic",
                    Duration = new DateTime(2016, 1, 1)
                };
                context.PaymentTiers.AddOrUpdate(basic);
                context.SaveChanges();

                ApplicationUser userOwner = new ApplicationUser
                {
                    Name = "Niko",
                    Surname = "Belic",
                    Email = "niko@belic.com",
                    UserName = "nbelic",
                    PasswordHash = "password",
                    IsBanned = false
                };
                userManager.Create(userOwner, "Password");
                context.SaveChanges();
                userManager.AddToRole(userOwner.Id, ownerRole);
                context.SaveChanges();

                Owner niko = new Owner
                {
                    OrganizationName = "Rockstar games",
                    SelectedTier = basic,
                    ApplicationUser = userOwner
                };
                context.Owners.Add(niko);
                context.SaveChanges();

                EventState active = new EventState
                {
                    Description = "Active",
                    Name = "Active"
                };
                context.EventStates.AddOrUpdate(active);
                context.SaveChanges();

                Event someEvent = new Event
                {
                    Name = "Event",
                    EventState = active,
                    Description = "Lorem ipsum",
                    StartDate = new DateTime(1996, 1, 1),
                    Owner = niko,
                    Latitude = 43.869946,
                    Longitude = 18.4182643
                };
                context.Events.AddOrUpdate(someEvent);
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\elvircrn\Documents\codes2\log.txt"))
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        file.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            file.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(@"C:\Users\elvircrn\Documents\codes2\log.txt"))
                {
                    file.WriteLine(e.ToString());
                }

                throw;
            }

        }
    }
}

