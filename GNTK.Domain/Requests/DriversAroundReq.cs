using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class DriversAroundReq
    {
        public decimal CustomerLatitude { get; set; }
        public decimal CustomerLongitude { get; set; }
    }
}
