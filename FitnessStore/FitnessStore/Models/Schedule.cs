using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessStore.Models
{
    public enum SelectAreaDublin
    {
        Balbriggan, Citywest, Clondalkin, Clonskeagh, Donabate, Drumcondra, [Display(Name = "Dublin City Centre")]
        DublinCityCentre, [Display(Name = "Dun Laoghaire")]
        DunLaoghaire, Dundrum, Fairview, Fingal, Finglas, Glasnevin,
        [Display(Name = "Grand Canal Dock")]
        GrandCanalDock, [Display(Name = "Harold's Cross")]
        HaroldsCross,
        Killiney, Lucan, Malahide, Millstown, Monkstown, [Display(Name = "Phoenix Park")]
        PhoenixPark, Raheny, Ranelagh, Rathfarnham, Rathmines, Ringsend, Sandymount, Smithfield, Stillorgan, Swords, Tallaght,
        [Display(Name = "Temple Bar")]
        TempleBar, Terenure
    }

    public enum Status { Available, [Display(Name = "Fully Booked")] Fullybooked}

    public class Schedule
    {
        //PK 
        [Key]
        public int ScheduleID { get; set; }
        public int CategoryID { get; set; }
        public int InstructorID { get; set; }

        //Area
        [Display(Name = "Dublin Area")]
        [Required(ErrorMessage = "Please select area")]
        public SelectAreaDublin? SelectAreaDublin { get; set; }

        //Class type
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        //Gym Name
        [Display(Name = "Gym Name")]
        [Required(ErrorMessage = "Please type your gym name")]
        public string GymName { get; set; }

        //Start date
        [DataType(DataType.Date), Display(Name = "Start Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        //Start Time
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        //Capacity
        [Display(Name = "Maximum Enrollment")]
        //[Range(1, 20, ErrorMessage = "Enrollment ranges from 1 to max 20")]
        public int MaxEnroll { get; set; }

        //Status
        public Status? Status { get; set; }

        public virtual ICollection<RegistrationRecord> Records { get; set; }

        }
}