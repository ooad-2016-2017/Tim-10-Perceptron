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
    public class CustomersController : ApiController
    {
        ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        // GET: api/Customers
        [Authorize(Roles ="ADMIN,CUSTOMER,OWNER")]
        public IHttpActionResult Get(int id)
        {
            Customer customer = _service.GetCustomer(id);

            if (customer == null)
                return BadRequest($"Customer with {id} not found");

            return Ok(_service.GetCustomer(id).ToCustomerDTO());
        }

        // GET: api/Customers
        [Authorize(Roles ="ADMIN,CUSTOMER,OWNER")]
        [Route("ByUser")]
        public IHttpActionResult Get(string id)
        {
            Customer customer = _service.GetCustomer(id);

            if (customer == null)
                return BadRequest($"Customer with {id} not found");

            return Ok(_service.GetCustomer(id).ToCustomerDTO());
        }


        // POST: api/Customers
        public void Post([FromBody]string value)
        {
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
