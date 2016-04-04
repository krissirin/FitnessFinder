using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessClassFinder1.Models;

namespace FitnessClassFinder1.ViewModels
{
    public class FitnessCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}