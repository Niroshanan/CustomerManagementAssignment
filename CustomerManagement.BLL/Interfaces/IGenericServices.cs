using CustomerManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.Interfaces
{
    public interface IGenericServices
    {
        ICustomerServices Customer { get; }
    }
}
