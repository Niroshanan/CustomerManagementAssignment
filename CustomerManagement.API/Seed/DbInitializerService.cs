using CustomerManagement.BLL.Unitily;
using CustomerManagement.DAL.Data;
using CustomerManagement.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CustomerManagement.API.Seed
{
    public class DatabaseInitializer : IDbInitializerService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _dbContext;

        public DatabaseInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        public async Task SeedCustomersAsync()
        {
            if (_dbContext.Customers.Any())
            {
                return;
            }
            string path = "../CustomerManagement.DAL/Data/UserData.json";
            string jsonString = System.IO.File.ReadAllText(path);
            var customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
            var customerList = new List<Customer>();
            var AddressList = new List<Address>();

            foreach (var item in customers)
            {
                Customer customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    _Id = item._Id,
                    Index = item.Index,
                    Age = item.Age,
                    EyeColor = item.EyeColor,
                    Name = item.Name,
                    Gender = item.Gender,
                    Company = item.Company,
                    Email = item.Email,
                    Phone = item.Phone,
                    About = item.About,
                    Registered = item.Registered,
                    Latitude = item.Latitude,
                    Longitude = item.Longitude,
                    Tags = item.Tags
                };
                _dbContext.Customers.Add(customer);
                customerList.Add(customer);

                Address address = new Address()
                {
                    Id = Guid.NewGuid(),
                    Number = item.Address.Number,
                    Street = item.Address.Street,
                    City = item.Address.City,
                    State = item.Address.State,
                    ZipCode = item.Address.ZipCode,
                    CustomerId = customer.Id
                };
                _dbContext.Addresses.Add(address);
                _dbContext.SaveChanges();
                AddressList.Add(address);
            }

        }
        public async Task SeedRoleAndUserAsync()
        {
            string[] roleNames = { SD.Admin,SD.User };

            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Add admin user if needed
            string adminEmail = "admin@example.com";
            string adminPassword = "Admin@123";
            if (await _userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await _userManager.CreateAsync(adminUser, adminPassword);
                await _userManager.AddToRoleAsync(adminUser, SD.Admin);
                await _userManager.AddToRoleAsync(adminUser, SD.User);
            }
        }
    }
}
