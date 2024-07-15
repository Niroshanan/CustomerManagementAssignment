using CustomerManagement.DAL.Data;
using CustomerManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Repositories.Implementations
{
    public class GenericRepository : IGenereicRepository
    {
        private readonly ApplicationDbContext _db;
        public ICustomerRepository Customer { get; private set; }
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            Customer = new CustomerRepository(_db);
        }

    }
}
