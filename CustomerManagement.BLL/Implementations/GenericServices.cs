using AutoMapper;
using CustomerManagement.BLL.Interfaces;
using CustomerManagement.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BLL.Implementations
{
    public class GenericServices : IGenericServices
    {
        private readonly IGenereicRepository _repository;

        private readonly IMapper _mapper;
        public ICustomerServices Customer { get; private set; }
        public GenericServices(IGenereicRepository genereicRepository,IMapper mapper)
        {
            _repository = genereicRepository;
            Customer = new CustomerServices(_repository, mapper);
        }
    }
}
