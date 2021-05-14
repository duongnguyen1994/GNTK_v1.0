using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.DAL.Interface
{
    public interface ILocationRepository
    {
        public Task<IEnumerable<ProvinceRes>> GetProvince();
        public Task<IEnumerable<DistrictRes>> GetDistrict(LocationReq request);
        public Task<IEnumerable<WardRes>> GetWard(LocationReq request);
    }
}
