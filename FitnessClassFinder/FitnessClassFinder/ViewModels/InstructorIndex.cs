using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FitnessClassFinder.Models;

namespace FitnessClassFinder.ViewModels
{
    public class InstructorIndex
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<ClassSchedule> Schedules { get; set; }
        public IEnumerable<RegistrationRecord> Records { get; set; }
    }
}