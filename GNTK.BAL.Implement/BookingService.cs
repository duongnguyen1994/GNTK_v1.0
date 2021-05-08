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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }


        public async Task<BookingInfoRes> GetBookingById(string bookingId)
        {
            try
            {
                if (!String.IsNullOrEmpty(bookingId))
                    return await bookingRepository.GetBookingById(bookingId);
                return new BookingInfoRes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
