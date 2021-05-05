﻿using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.BAL.Interface
{
    public interface IBookingService
    {
        public Task<IEnumerable<BookingsAroundRes>> GetBookingsAround(BookingsAroundReq request);
        public Task<BookingInfoRes> GetBookingById(string bookingId);
        public Task<BookingTransportRes> BookingTransport(BookingTransportReq request);
    }
}
