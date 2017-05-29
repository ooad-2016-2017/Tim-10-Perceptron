using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.Models;

namespace InteraktivnaMapaEvenata.WebAPI.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using InteraktivnaMapaEvenata.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Flag>("Flags");
    builder.EntitySet<Customer>("Users"); 
    builder.EntitySet<FlagState>("FlagStates"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class FlagsController : ODataController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: odata/Flags
        [EnableQuery]
        public IQueryable<Flag> GetFlags()
        {
            return db.Flags;
        }

        // GET: odata/Flags(5)
        [EnableQuery]
        public SingleResult<Flag> GetFlag([FromODataUri] int key)
        {
            return SingleResult.Create(db.Flags.Where(flag => flag.FlagId == key));
        }

        // PUT: odata/Flags(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Flag> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Flag flag = db.Flags.Find(key);
            if (flag == null)
            {
                return NotFound();
            }

            patch.Put(flag);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlagExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(flag);
        }

        // POST: odata/Flags
        public IHttpActionResult Post(Flag flag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Flags.Add(flag);
            db.SaveChanges();

            return Created(flag);
        }

        // PATCH: odata/Flags(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Flag> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Flag flag = db.Flags.Find(key);
            if (flag == null)
            {
                return NotFound();
            }

            patch.Patch(flag);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlagExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(flag);
        }

        // DELETE: odata/Flags(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Flag flag = db.Flags.Find(key);
            if (flag == null)
            {
                return NotFound();
            }

            db.Flags.Remove(flag);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Flags(5)/Customer
        [EnableQuery]
        public SingleResult<Customer> GetCustomer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Flags.Where(m => m.FlagId == key).Select(m => m.Customer));
        }

        // GET: odata/Flags(5)/FlagState
        [EnableQuery]
        public SingleResult<FlagState> GetFlagState([FromODataUri] int key)
        {
            return SingleResult.Create(db.Flags.Where(m => m.FlagId == key).Select(m => m.FlagState));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FlagExists(int key)
        {
            return db.Flags.Count(e => e.FlagId == key) > 0;
        }
    }
}
