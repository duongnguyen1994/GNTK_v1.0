using Dapper;
using GNTK.DAL.Interface;
using GNTK.Domain.Entities;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.DAL.Implement
{
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        private readonly UserManager<AppIdentityUser> userManager;

        public DriverRepository(IConfiguration configuration,
            UserManager<AppIdentityUser> userManager) : base(configuration)
        {
            this.userManager = userManager;
        }

        public async Task<BookingRes> AcceptBooking(BookingReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookingId", request.BookingId);
                parameters.Add("@DriverId", request.DriverId);
                return await SqlMapper.QueryFirstAsync<BookingRes>(
                                                cnn: connection,
                                                sql: "sp_AcceptBooking",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DriverId", driverId);
                return await SqlMapper.QueryFirstAsync<DriverStatusRes>(
                                                cnn: connection,
                                                sql: "sp_ChangeStatusOfDriver",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                var driver = new AppIdentityUser()
                {
                    Email = request.Email,
                    UserName = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Fullname = request.Fullname,
                    Avatar = request.Avatar,
                    IdentityCardNumber = request.IdentityCardNumber,
                    DrivingLicenseNumber = request.DrivingLicenseNumber,
                    WardId = request.Ward,
                    DistrictId = request.District,
                    ProvinceId = request.Province,
                    CountryId = request.Country,
                    JoinDate = DateTime.Now,
                    Address = request.Address
                };
                var result = await userManager.CreateAsync(driver, request.Password);
                if (result.Succeeded)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@UserId", driver.Id);
                    parameters.Add("@RoleId", "2");
                    var newDriver = await SqlMapper.QueryFirstAsync<DriverRegisterRes>(
                                                    cnn: connection,
                                                    sql: "sp_AddRoleToUser",
                                                    param: parameters,
                                                    commandType: CommandType.StoredProcedure);
                    if (newDriver.Message == "Successful!")
                    {
                        DynamicParameters paras = new DynamicParameters();
                        paras.Add("@DriverId", driver.Id);
                        paras.Add("@VehicleRegistrationCertificateNumber", request.Vehicle.VehicleRegistrationCertificateNumber);
                        paras.Add("@Brand", request.Vehicle.Brand);
                        paras.Add("@Color", request.Vehicle.Color);
                        paras.Add("@NumberPlate", request.Vehicle.NumberPlate);
                        var vehicle = await SqlMapper.QueryFirstAsync<bool>(
                                                        cnn: connection,
                                                        sql: "[dbo].[sp_AddDriverVehicle]",
                                                        param: paras,
                                                        commandType: CommandType.StoredProcedure);
                        if (vehicle)
                            return newDriver;
                        return new DriverRegisterRes()
                        {
                            Id = "",
                            Message = "Phương tiện này đã đăng ký"
                        };
                    }
                }
                return new DriverRegisterRes()
                {
                    Id = "",
                    Message = "Không thể đăng ký, xin hãy thử lại"
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookingId", request.BookingId);
                parameters.Add("@DriverId", request.DriverId);
                return await SqlMapper.QueryFirstAsync<BookingRes>(
                                                cnn: connection,
                                                sql: "sp_DropedOffCustomer",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                return await SqlMapper.QueryAsync<DriverRes>(
                                                cnn: connection,
                                                sql: "sp_GetDrivers",
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DriverId", driverId);
                return await SqlMapper.QueryFirstAsync<DriverRes>(
                                                cnn: connection,
                                                sql: "sp_GetDriverById",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DriverId", request.DriverId);
                parameters.Add("@BookingId", request.BookingId);
                return await SqlMapper.QueryFirstAsync<BookingRes>(
                                                cnn: connection,
                                                sql: "sp_PickedUpCustomer",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DriverId", request.DriverId);
                parameters.Add("@InRadius", request.InRadius);
                return await SqlMapper.QueryAsync<BookingsAroundRes>(
                                                cnn: connection,
                                                sql: "sp_GetBookingsAround",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DriverId", request.DriverId);
                parameters.Add("@Latitude", request.Latitude);
                parameters.Add("@Longitude", request.Longitude);
                return await SqlMapper.QueryFirstAsync<UpdateDriverLocationRes>(
                                                cnn: connection,
                                                sql: "sp_UpdateDriverLocation",
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
