using Customer.Microservice.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Microservice.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       
        public async Task CreateCustomer(Entities.Customer customer)
        {
            dbContext.Add(customer);
            await SaveChanges();
        }


        public async Task DeleteCustomer(Guid Id)
        {
            var customer = dbContext.Customers.Find(Id);
            dbContext.Customers.Remove(customer);
            await SaveChanges();
        }

        public async Task<Entities.Customer> GetCustomerById(Guid Id)
        {
            return await dbContext.Customers.FindAsync(Id);
        }

        public async Task<IEnumerable<Entities.Customer>> GetCustomers()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task UpdateCustomer(Guid id, Entities.Customer customerData)
        {
            var customer = dbContext.Customers.Find(id);
           


            customer.City = customerData.City;
            customer.Name = customerData.Name;
            customer.Contact = customerData.Contact;
            customer.Email = customerData.Email;

           // dbContext.Entry(customer).State = EntityState.Modified;
            dbContext.Update(customer);
           
            await SaveChanges();

        }


        public async Task<int> SaveChanges()
        {
            return await dbContext.SaveChangesAsync();
        }

      
    }
}
