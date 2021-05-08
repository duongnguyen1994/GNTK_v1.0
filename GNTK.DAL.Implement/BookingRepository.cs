using Dapper;
using GNTK.DAL.Interface;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.DAL.Implement
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {

        public BookingRepository(IConfiguration configuration) : base(configuration)
        {

        }


        public async Task<BookingInfoRes> GetBookingById(string bookingId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookingId", bookingId);
                return await SqlMapper.QueryFirstAsync<BookingInfoRes>(
                                                cnn: connection,
                                                sql: "sp_GetBookingById",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
