using CustomerManagement.DAL.Data;
using CustomerManagement.DAL.Entities;
using CustomerManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
            return customer == null ? throw new Exception("Customer not found") : customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var customerList = await _dbContext.Customers.Include(c=> c.Address).ToListAsync();
            return customerList;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            _dbContext.Customers.Update(customer);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<IGrouping<int , Customer>>> GroupByZipCode()
        {
            var customersGroupedByZipCode = await _dbContext.Customers.Include(c => c.Address).GroupBy(c => c.Address.ZipCode).ToListAsync();
            return customersGroupedByZipCode;

        }
    }
}
