using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNTK.BAL.Interface
{
    public interface IDriverService
    {
        public Task<DriverRegisterRes> CreateDriver(DriverRegisterReq request);
        public Task<BookingRes> AcceptBooking(BookingReq request);
        public Task<DriverStatusRes> ChangeDriverStatus(string driverId);
        public Task<BookingRes> PickedUpCustomer(BookingReq request);
        public Task<BookingRes> DropedOffCustomer(BookingReq request);
        public Task<DriverRes> GetDriverById(string driverId);
        public Task<IEnumerable<DriverRes>> GetDrivers();
    }
}
