using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoicePlatform.Data;
using VoicePlatform.Data.Repositories;
using VoicePlatform.Service.Interfaces;

namespace VoicePlatform.Service.Implementations
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _customerRepository = unitOfWork.Customer;
        }
    }
}
