using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class DriverStatusReq
    {
        public string DriverId { get; set; }
        public bool Status { get; set; }
    }
}
