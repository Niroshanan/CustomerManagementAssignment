using AutoMapper;
using CustomerManagement.BLL.DTOs;
using CustomerManagement.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.Unitily
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Customer, CustomerEditDto>().ReverseMap();
            CreateMap<CustomerEditDto, Customer>();
        }
    }
}
