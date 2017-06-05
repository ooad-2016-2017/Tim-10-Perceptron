using InteraktivnaMapaEvenata.BLL.Interfaces;
using InteraktivnaMapaEvenata.Common.DTOs;
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
    public class CustomersController : ApiController
    {
        ICustomerService _service;

        public CustomersController() { }
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [Authorize(Roles ="ADMIN")]
        public IHttpActionResult Get()
        {
            return Ok(_service.GetCustomers());
        }

        // GET: api/Customers
        [Authorize(Roles ="ADMIN,CUSTOMER,OWNER")]
        public IHttpActionResult Get(int id)
        {
            CustomerDTO customer = _service.GetCustomer(id);

            if (customer == null)
                return BadRequest($"Customer with {id} not found");

            return Ok(customer);
        }

        // GET: api/Customers
        [Authorize(Roles ="ADMIN,CUSTOMER,OWNER")]
        [Route("api/Customers/ByUser/{id}")]
        public IHttpActionResult Get(string id)
        {
            CustomerDTO customer = _service.GetCustomer(id);

            if (customer == null)
                return BadRequest($"Customer with {id} not found");

            return Ok(customer);
        }


        // POST: api/Customers/follow/{customerid}/{ownerid}
        [Authorize(Roles="ADMIN,CUSTOMER")]
        [Route("api/Customers/follow/{customerId}/{ownerId}")]
        public IHttpActionResult Post(int customerId, int ownerId)
        {
            return Ok(_service.Follow(customerId, ownerId));
        }

        // POST: api/Customers/follow/{customerid}/{ownerid}
        [Authorize(Roles = "ADMIN,CUSTOMER")]
        [Route("api/Customers/unfollow/{customerId}/{ownerId}")]
        public IHttpActionResult PostUnfollow(int customerId, int ownerId)
        {
            return Ok(_service.Unfollow(customerId, ownerId));
        }

        // PUT: api/Customers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customers/5
        public void Delete(int id)
        {
        }
    }
}
