using Customer.Microservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository repo;

        public CustomersController(ICustomerRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await repo.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}", Name ="CustomerById")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await repo.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult>CreateCustomer([FromBody] Entities.Customer customer)
        {
            await repo.CreateCustomer(customer);
            return CreatedAtRoute("CustomerById", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] Entities.Customer customer)
        {
            
            if (customer != null)
            {
                await repo.UpdateCustomer(id, customer);
                return new OkResult();
               
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteCustomer(Guid id)
        {
            await repo.DeleteCustomer(id);
            return new OkResult();
        }
    }
}
