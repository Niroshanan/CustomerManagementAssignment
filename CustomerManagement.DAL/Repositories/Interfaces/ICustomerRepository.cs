using CustomerManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<bool> UpdateCustomerAsync(Customer customer);

        Task<List<IGrouping<int, Customer>>> GroupByZipCode();

    }
}
