//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;

//namespace FitnessClassFinder.Models
//{
//    public class BookingCart
//    {
//        [Key]
//        public int BookingId { get; set; }
//        public string CartId { get; set; }
//        public int ScheduleID { get; set; }
//        public int Count { get; set; }
//        public DateTime DateCreated { get; set; }
//        public virtual ClassSchedule schedules { get; set; }
//    }
//    public class BookingDetail
//    {
//        [Key]
//        public int BookingDetailID { get; set; }
//        public int BookingOrderID { get; set; }
//        public int ScheduleID { get; set; }
//        public int Quantity { get; set; }
//        public virtual ClassSchedule Schedule { get; set; }
//        public virtual BookingOrder BookingOrder { get; set; }
//    }

//    public class BookingOrder
//    {
//        [Key]
//        public int BookingOrderID { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Address { get; set; }
//        public string Phone { get; set; }
//        public string Email { get; set; }
//        public decimal Total { get; set; }
//        public DateTime OrderDate { get; set; }
//        public List<BookingDetail> BookingDetails { get; set; }
//    }

//}