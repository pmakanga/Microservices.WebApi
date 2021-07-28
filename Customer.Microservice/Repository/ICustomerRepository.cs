using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Entities.Customer>> GetCustomers();
        Task<Entities.Customer> GetCustomerById(Guid Id);
        Task CreateCustomer(Entities.Customer customer);
        Task UpdateCustomer(Guid id, Entities.Customer customer);
        Task DeleteCustomer(Guid Id);
        Task<int> SaveChanges();

    }
}
