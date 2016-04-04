using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessClassFinder1.Models;

namespace FitnessClassFinder1.ViewModels
{
    public class FitnessCartViewModel
    {
        public List<BookingCart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}