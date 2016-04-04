using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessClassFinder.Models;

namespace FitnessClassFinder.ViewModels
{
    public class SchedulePagedList
    {
        public PagedList.IPagedList<ClassSchedule> Schedules { get; set; }
    }
}