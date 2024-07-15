using AutoMapper;
using CustomerManagement.BLL.DTOs;
using CustomerManagement.BLL.Interfaces;
using CustomerManagement.BLL.Unitily;
using CustomerManagement.DAL.Entities;
using CustomerManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.Implementations
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IGenereicRepository _genereicRepository;
        private readonly IMapper _mapper;

        public CustomerServices(IGenereicRepository genereicRepository, IMapper mapper)
        {
            _genereicRepository = genereicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            try
            {
                return await _genereicRepository.Customer.GetCustomersAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<double?> GetDistanceAsync(Guid customerId, CordinateDto userCordinate)
        {
            try
            {
                var customer = await _genereicRepository.Customer.GetCustomerByIdAsync(customerId);
                var log = customer.Longitude;
                var lat = customer.Latitude;
                CordinateDto customerCordinate = new CordinateDto { Latitude = lat, Longitude = log };

                double distance = Helpers.CalculateDistance(customerCordinate, userCordinate);
                return distance;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            try
            {
                return await _genereicRepository.Customer.GetCustomerByIdAsync(customerId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateCustomerAsync(Guid id, CustomerEditDto customer)
        {
            try
            {
                Customer customerFromDb = await GetCustomerByIdAsync(id) ??
                    throw new Exception("Customer not found");
                if (!string.IsNullOrEmpty(customer.Name))
                {
                    customerFromDb.Name = customer.Name;
                }
                if (!string.IsNullOrEmpty(customer.Email))
                {
                    customerFromDb.Email = customer.Email;
                }
                if (!string.IsNullOrEmpty(customer.Phone))
                {
                    customerFromDb.Phone = customer.Phone;
                }

                if (!await _genereicRepository.Customer.UpdateCustomerAsync(customerFromDb))
                {
                    throw new Exception("Failed to update customer");
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<Customer>> SearchCustomerAsync(string searchStr)
        {
            IEnumerable<Customer> customers = await _genereicRepository.Customer.GetCustomersAsync();
            IEnumerable<Customer> result = Helpers.FilterCustomers(customers, searchStr);
            return result;
        }

        public async Task<IEnumerable<CustomerGroupDto>> GroupByZipCodeAsync()
        {
            var customersListByZipCode = await _genereicRepository.Customer.GroupByZipCode();
            var result = customersListByZipCode.Select(group => new CustomerGroupDto
            {
                ZipCode = group.Key,
                Customers = group.ToList()
            });
            return result;
        }

    }
}
