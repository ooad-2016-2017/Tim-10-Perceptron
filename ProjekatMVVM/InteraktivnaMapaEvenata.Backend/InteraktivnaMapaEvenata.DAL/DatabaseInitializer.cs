using InteraktivnaMapaEvenata.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivnaMapaEvenata.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
    }
}
