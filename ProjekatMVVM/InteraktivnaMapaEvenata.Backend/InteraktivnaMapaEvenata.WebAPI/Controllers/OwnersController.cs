using InteraktivnaMapaEvenata.BLL.Interfaces;
using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Common.Mappers;
using InteraktivnaMapaEvenata.Models;
using Ninject;
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
        // GET: api/Owners/5
        public IHttpActionResult Get(int id)
        {
            OwnerDTO owner = _service.GetOwner(id);
            if (owner == null)
                return BadRequest($"Owner with id ${id} not found.");
            return Ok(owner);
        }

        [Route("api/Owners/ByUser/{userId}")]
        public IHttpActionResult Get(string userId)
        {
            OwnerDTO owner = _service.GetOwner(userId);
            if (owner == null)
                return BadRequest($"Owner with userId ${userId} not found.");
            return Ok(owner);
        }

        [Inject]
        public IEventService EventService { private get; set; }

        [Route("api/Owners/LatestEvent/{eventId}")]
        [Authorize(Roles="ADMIN,OWNER")]
        public IHttpActionResult GetLatest(int eventId)
        {
            return Ok(EventService.GetLatestEvent(eventId));
        }

        // GET: api/Owners
        [Authorize(Roles="ADMIN,CUSTOMER,OWNER")]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetOwners());
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
