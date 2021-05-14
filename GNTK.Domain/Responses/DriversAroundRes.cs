using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Responses
{
    public class DriversAroundRes
    {
        public string DriverId { get; set; }
        public string Fullname { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
