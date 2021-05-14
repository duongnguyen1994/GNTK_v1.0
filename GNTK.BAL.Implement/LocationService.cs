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
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public async Task<IEnumerable<DistrictRes>> GetDistrict(LocationReq request)
        {
            try
            {
                if (request != null)
                    return await locationRepository.GetDistrict(request);
                return null;
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
                return await locationRepository.GetProvince();
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
                if (request != null)
                    return await locationRepository.GetWard(request);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
