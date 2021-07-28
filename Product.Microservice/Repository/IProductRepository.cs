using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Microservice.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> GetProducts();
        Task<Entities.Product> GetProductById(Guid Id);
        Task CreateProduct(Entities.Product product);
        Task UpdateProduct(Guid id, Entities.Product product);
        Task DeleteProduct(Guid Id);
        Task<int> SaveChanges();
    }
}
