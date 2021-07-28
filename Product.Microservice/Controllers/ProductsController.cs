using Microsoft.AspNetCore.Mvc;
using Product.Microservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repo;

        public ProductsController(IProductRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await repo.GetProducts();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult>GetProductById(Guid id)
        {
            var customer = await repo.GetProductById(id);
            return Ok(customer);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Entities.Product product)
        {
            await repo.CreateProduct(product);
            return CreatedAtRoute("ProductById", new { id = product.Id }, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] Entities.Product product)
        {
            if (product != null)
            {
                await repo.UpdateProduct(id, product);
                return new OkResult();

            }
            return new NoContentResult();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await repo.DeleteProduct(id);
            return new OkResult();
        }
    }
}
