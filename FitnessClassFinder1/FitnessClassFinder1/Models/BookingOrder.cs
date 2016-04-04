using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder1.Models
{
    public class BookingOrder
    { 
    public int BookingOrderID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
    public List<BookingDetail> BookingDetails { get; set; }
    }
}