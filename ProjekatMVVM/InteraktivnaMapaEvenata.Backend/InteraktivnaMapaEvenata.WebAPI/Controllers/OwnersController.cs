using InteraktivnaMapaEvenata.BLL.Interfaces;
using InteraktivnaMapaEvenata.Common.Mappers;
using InteraktivnaMapaEvenata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InteraktivnaMapaEvenata.WebAPI.Controllers
{
    [Authorize]
    public class OwnersController : ApiController
    {
        IOwnersService _service;

        public OwnersController(IOwnersService service)
        {
            _service = service;
        }

        // GET: api/Owners
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Owners/5
        public IHttpActionResult Get(int id)
        {
            Owner owner = _service.GetOwner(id);
            if (owner == null)
                return BadRequest($"Owner with id ${id} not found.");
            return Ok(owner.ToOwnerDTO());
        }

        [Route("ByUser")]
        public IHttpActionResult Get(string userId)
        {
            Owner owner = _service.GetOwner(userId);
            if (owner == null)
                return BadRequest($"Owner with userId ${userId} not found.");
            return Ok(owner.ToOwnerDTO());
        }

        // POST: api/Owners
        [Authorize]
        public void Post([FromBody]Event _event)
        {
            
        }

        // PUT: api/Owners/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Owners/5
        public void Delete(int id)
        {
        }
    }
}
