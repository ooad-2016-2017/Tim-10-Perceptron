using InteraktivnaMapaEvenata.BLL.Interfaces;
using InteraktivnaMapaEvenata.Common.DTOs;
using InteraktivnaMapaEvenata.Common.Validators;
using InteraktivnaMapaEvenata.DAL;
using InteraktivnaMapaEvenata.Models;
using InteraktivnaMapaEvenata.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InteraktivnaMapaEvenata.WebAPI.Controllers
{
    //[Authorize]
    public class EventController : ApiController
    {
        IEventService _service;

        public EventController() { }

        public EventController(IEventService service)
        {
            _service = service;
        }

        // GET: api/Event
        //[Authorize(Roles = "ADMIN,CUSTOMER,OWNER")]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetEvents());
        }

        // GET: api/Event/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_service.GetEventById(id));
        }

        // POST: api/Event
        //[Authorize(Roles = "OWNER,ADMIN")]
        public IHttpActionResult Post([FromBody]Event eventObj)
        {
            List<string> errors;
            if (!eventObj.IsValid(out errors))
                return BadRequest("Validation errors:\n" + string.Join("\n", errors.ToArray()));
            Event ret = _service.AddEvent(eventObj);
            if (ret == null)
                return BadRequest("Failed to add event.");
            return Ok(ret);
        }

        // PUT: api/Event
        [Authorize(Roles = "OWNER,ADMIN")]
        public IHttpActionResult Put([FromBody]Event eventObj)
        {
            List<string> errors;
            if (!eventObj.IsValid(out errors))
                return BadRequest("Validation errors:\n" + string.Join("\n", errors.ToArray()));
            Event ret = _service.Update(eventObj);
            if (ret == null)
                return BadRequest("Failed to add event");
            return Ok(ret);
        }

        [Authorize(Roles="CUSTOMER")]
        [Route("api/event/signupcustomer/{id}")]
        public IHttpActionResult Put(int id, [FromBody]CustomerDTO customer)
        {
            return Ok(_service.SignUpCustomer(id, customer));
        }

        // DELETE: api/Event/5
        //public IHttpActionResult Pelete(int id)
        //{
        //}
    }
}
