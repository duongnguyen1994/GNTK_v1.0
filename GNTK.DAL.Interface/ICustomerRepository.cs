using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.DAL.Interface
{
    public interface ICustomerRepository
    {
        public Task<CustomerRegisterRes> CreateCustomer(CustomerRegisterReq request);
        public Task<CustomerRes> GetCustomerById(string customerId);
        public Task<IEnumerable<CustomerRes>> GetCustomers();
    }
}
