using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DAL.Repositories.Interfaces
{
    public interface IGenereicRepository
    {
        ICustomerRepository Customer { get; }
    }
}
