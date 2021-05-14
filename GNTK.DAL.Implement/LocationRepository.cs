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
    public class LocationRepository : BaseRepository, ILocationRepository
    {
        public LocationRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IEnumerable<DistrictRes>> GetDistrict(LocationReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProvinceId", request.ProvinceId);
                return await SqlMapper.QueryAsync<DistrictRes>(
                                                cnn: connection,
                                                sql: "sp_GetDistrict",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ProvinceRes>> GetProvince()
        {
            try
            {
                return await SqlMapper.QueryAsync<ProvinceRes>(
                                                cnn: connection,
                                                sql: "sp_GetProvince",
                                                commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<WardRes>> GetWard(LocationReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ProvinceId", request.ProvinceId);
                parameters.Add("@DistrictId", request.DistrictId);
                return await SqlMapper.QueryAsync<WardRes>(
                                                cnn: connection,
                                                sql: "sp_GetWard",
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
