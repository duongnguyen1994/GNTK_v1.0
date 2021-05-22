using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Responses
{
    public class BookingsAroundRes
    {
        public string BookingId { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal InRadius { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationAddress { get; set; }
    }
}
