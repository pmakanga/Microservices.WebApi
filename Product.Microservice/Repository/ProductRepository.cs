using Microsoft.EntityFrameworkCore;
using Product.Microservice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateProduct(Entities.Product product)
        {
            dbContext.Products.Add(product);
            await SaveChanges();
        }

        public async Task DeleteProduct(Guid Id)
        {
            var product = dbContext.Products.Find(Id);
            dbContext.Products.Remove(product);
            await SaveChanges();
        }

        public async Task<Entities.Product> GetProductById(Guid Id)
        {
            return await dbContext.Products.FindAsync(Id);
        }

        public async Task<IEnumerable<Entities.Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }


        public async Task UpdateProduct(Guid id, Entities.Product productData)
        {
            var product = dbContext.Products.Find(id);
            product.Name = productData.Name;
            product.Rate = productData.Rate;

            dbContext.Update(product);

            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
