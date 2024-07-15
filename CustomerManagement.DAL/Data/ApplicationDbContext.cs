using CustomerManagement.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CustomerManagement.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(cd => cd.Customer)
                .HasForeignKey<Address>(cd => cd.CustomerId);

        }

        public async void SeedCustomersAsync(ModelBuilder modelBuilder)
        {
            string path = "../CustomerManagement.DAL/Data/UserData.json";
            string jsonString = System.IO.File.ReadAllText(path);
            var customers = JsonSerializer.Deserialize<List<Customer>>(jsonString);
            foreach (var item in customers)
            {
                Customer customer = new Customer()
                {
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
                modelBuilder.Entity<Customer>().HasData(customer);
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
                modelBuilder.Entity<Address>().HasData(address);
            }

        }
    }
}
