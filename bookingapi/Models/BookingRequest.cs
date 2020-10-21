using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookingapi.Models
{
    public class BookingRequest
    {
        public string seatId { get; set; }
        public string userId { get; set; }

        public string startTime { get; set; }

        public string endtime { get; set; }


    }
}
