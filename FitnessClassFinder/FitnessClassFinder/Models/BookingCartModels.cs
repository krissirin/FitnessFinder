using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FitnessClassFinder.Models
{
    public class BookingCart
    {
        [Key]
        public string BookingId { get; set; }
        public string BookingCartId { get; set; }
        public int FitnessClassID { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ClassSchedule Schedules { get; set; }
    }

    public class BookingOrder
    {
        [Key]
        public int BookingOrderId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public string Address { get; set; }

        // numbers only, lenght 8-12
        [RegularExpression("[0-9]{8,12}", ErrorMessage = "Phone is required, No spaces allowed, 8 -12 digits.")]
        [Display(Name = "Phone No.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public decimal Total { get; set; }

        public DateTime BookingDate { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }
    }

    public class BookingDetail
    {
        [Key]
        public int BookingDetailId { get; set; }
        public int BookingOrderId { get; set; }
        public int FitnessClassID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ClassSchedule schedules { get; set; }
        public virtual BookingOrder BookingOrder { get; set; }
    }


}