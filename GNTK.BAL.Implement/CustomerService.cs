using GNTK.BAL.Interface;
using GNTK.DAL.Interface;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.BAL.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<BookingTransportRes> BookingTransport(BookingTransportReq request)
        {
            try
            {
                if (request != null)
                    return await customerRepository.BookingTransport(request);
                return new BookingTransportRes()
                {
                    BookingId = "",
                    Message = "Có lỗi xảy ra, xin hãy liên hệ với tổng đài để khắc phục"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerRegisterRes> CreateCustomer(CustomerRegisterReq request)
        {
            try
            {
                var result = await customerRepository.CreateCustomer(request);
                if(!String.IsNullOrEmpty(result.Id))
                {
                    return result;
                }
                result.Id = "";
                result.Message = "Something went wrong please try again";
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerRes> GetCustomerById(string customerId)
        {
            try
            {
                if(!String.IsNullOrEmpty(customerId))
                    return await customerRepository.GetCustomerById(customerId);
                return new CustomerRes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<CustomerRes>> GetCustomers()
        {
            return await customerRepository.GetCustomers();
        }

        public async Task<IEnumerable<DriversAroundRes>> GetDriversAround(DriversAroundReq request)
        {
            try
            {
                if(request != null)
                {
                    return await customerRepository.GetDriversAround(request);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
