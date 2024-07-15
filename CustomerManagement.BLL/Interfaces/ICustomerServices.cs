using CustomerManagement.BLL.DTOs;
using CustomerManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.Interfaces
{
    public interface ICustomerServices
    {
        public Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<double?> GetDistanceAsync(Guid customerId,CordinateDto cordinateDto);
        Task<bool> UpdateCustomerAsync(Guid id, CustomerEditDto customer);

        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<IEnumerable<Customer>> SearchCustomerAsync(string name);
        Task<IEnumerable<CustomerGroupDto>> GroupByZipCodeAsync();
    }
}
