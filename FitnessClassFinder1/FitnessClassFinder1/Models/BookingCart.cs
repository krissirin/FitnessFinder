using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder1.Models
{
    public class BookingCart
    { 
    [Key]
    public int BookingId { get; set; }
    public string CartId { get; set; }
    public int ScheduleID { get; set; }
    public int Count { get; set; }
    public DateTime DateCreated { get; set; }
    public virtual Schedule schedules { get; set; }
    }
}