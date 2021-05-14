using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class BookingTransportReq
    {
        public decimal Distance { get; set; }
        public decimal UnitPrice { get; set; }
        public string CustomerId { get; set; }
        public string DiscountId { get; set; }
        public decimal PickedUpLatitude { get; set; }
        public decimal PickedUpLongitude { get; set; }
        public decimal DropedOffLatitude { get; set; }
        public decimal DropedOffLongitude { get; set; }
        public string OriginAddress { get; set; }
        public string DestinationAddress { get; set; }
    }
}
