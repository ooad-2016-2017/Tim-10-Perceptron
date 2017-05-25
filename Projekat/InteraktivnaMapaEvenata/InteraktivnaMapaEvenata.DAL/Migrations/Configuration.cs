namespace InteraktivnaMapaEvenata.DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InteraktivnaMapaEvenata.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        const string _adminRole = "Administrator";
        const string _customerRole = "Customer";
        const string _ownerRole = "Owner";
        const string _deviceRole = "Device";

        protected void SeedRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            if (!context.Roles.Any(r => r.Name == _adminRole))
                roleManager.Create(new IdentityRole { Name = _adminRole });

            if (!context.Roles.Any(r => r.Name == _customerRole))
                roleManager.Create(new IdentityRole { Name = _customerRole });

            if (!context.Roles.Any(r => r.Name == _ownerRole))
                roleManager.Create(new IdentityRole { Name = _ownerRole });

            if (!context.Roles.Any(r => r.Name == _deviceRole))
                roleManager.Create(new IdentityRole { Name = _deviceRole });

            context.SaveChanges();
        }

        public void SeedAdmin()
        {

        }

        public void SeedActivities()
        {

        }

        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            SeedRoles(context);

            context.SaveChanges();
        }
    }
}
