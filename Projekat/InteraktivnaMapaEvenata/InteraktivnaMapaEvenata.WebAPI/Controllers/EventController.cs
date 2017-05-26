using InteraktivnaMapaEvenata.BLL.Interfaces;
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
    public class EventController : ApiController
    {
        IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        // GET: api/Event
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Event/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Event/5
        public void Delete(int id)
        {
        }
    }
}
