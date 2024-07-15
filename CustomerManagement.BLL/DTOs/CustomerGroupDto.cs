using CustomerManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.DTOs
{
    public class CustomerGroupDto
    {
        public int ZipCode { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
