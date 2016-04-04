using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessClassFinder1.Models
{
    public class BookingDetail
    {
        public int BookingDetailID { get; set; }
        public int BookingOrderID { get; set; }
        public int ScheduleID { get; set; }
        public int Quantity { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual BookingOrder BookingOrder { get; set; }
    }
}