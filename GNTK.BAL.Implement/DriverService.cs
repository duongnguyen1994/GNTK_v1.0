using GNTK.BAL.Interface;
using GNTK.DAL.Interface;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNTK.BAL.Implement
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }

        public async Task<BookingRes> AcceptBooking(BookingReq request)
        {
            try
            {
                if (request != null)
                    return await driverRepository.AcceptBooking(request);
                return new BookingRes()
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

        public async Task<DriverStatusRes> ChangeDriverStatus(string driverId)
        {
            try
            {
                if (!String.IsNullOrEmpty(driverId))
                    return await driverRepository.ChangeDriverStatus(driverId);
                return new DriverStatusRes()
                {
                    DriverId = "",
                    Message = "Có lỗi xảy ra, xin hãy liên hệ với tổng đài để khắc phục"
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<DriverRegisterRes> CreateDriver(DriverRegisterReq request)
        {
            try
            {
                if(request!=null)
                    return await driverRepository.CreateDriver(request);
                return new DriverRegisterRes()
                {
                    Id = "",
                    Message = "Something went wrong please try again"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookingRes> DropedOffCustomer(BookingReq request)
        {
            try
            {
                if (request != null)
                    return await driverRepository.DropedOffCustomer(request);
                return new BookingRes()
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

        public async Task<IEnumerable<DriverRes>> GetDrivers()
        {
            try
            {
                return await driverRepository.GetDrivers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DriverRes> GetDriverById(string driverId)
        {
            try
            {
                if (!String.IsNullOrEmpty(driverId))
                    return await driverRepository.GetDriverById(driverId);
                return new DriverRes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookingRes> PickedUpCustomer(BookingReq request)
        {
            try
            {
                if (request != null)
                    return await driverRepository.PickedUpCustomer(request);
                return new BookingRes()
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

        public async Task<IEnumerable<BookingsAroundRes>> GetBookingsAround(BookingsAroundReq request)
        {
            try
            {
                if (request != null)
                {
                    return await driverRepository.GetBookingsAround(request);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UpdateDriverLocationRes> UpdateDriverLocation(UpdateDriverLocationReq request)
        {
            try
            {
                if (request != null)
                {
                    return await driverRepository.UpdateDriverLocation(request);
                }
                return new UpdateDriverLocationRes()
                {
                    DriverId = "",
                    Message = "Lỗi không thể cập nhật vị trí"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
