using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder1.Models
{
    // Schedule class
    // Enum

    //public enum SelectAreaDublin
    //{
    //    Balbriggan, Citywest, Clondalkin, Clonskeagh, Donabate, Drumcondra, [Display(Name = "Dublin City Centre")]
    //    DublinCityCentre, [Display(Name = "Dun Laoghaire")]DunLaoghaire, Dundrum, Fairview, Fingal, Finglas, Glasnevin,
    //    [Display(Name = "Grand Canal Dock")]GrandCanalDock, [Display(Name = "Harold's Cross")]HaroldsCross,
    //    Killiney, Lucan, Malahide, Millstown, Monkstown, [Display(Name = "Phoenix Park")]
    //    PhoenixPark, Raheny, Ranelagh, Rathfarnham, Rathmines, Ringsend, Sandymount, Smithfield, Stillorgan, Swords, Tallaght,
    //    [Display(Name = "Temple Bar")]TempleBar, Terenure
    //}

    //public enum SelectClass
    //{
    //    Abs, [Display(Name = "Aqua Aerobics")]AquaAerobics, [Display(Name = "Body Sculpt")]BodySculpt, Bootcamp, Boxing, Circuits,
    //    [Display(Name = "Core Training")]CoreTraining, [Display(Name = "Cross-Fit")]CrossFit, HIIT, Kettlebells, Kickboxing,
    //    [Display(Name = "Personal Training")]PersonalTraining, Pilates, Spinning, Step, Swimming, TRX,
    //    [Display(Name = "Weight Training")]WeightTraining, Yoga, Zumba
    //}

    public enum Status { Available, [Display(Name = "Fully Booked")] Fullybooked }

    //Properties
    public class Schedule
    {
        //PK 
        [Key]
        public int ScheduleID { get; set; }

        public int CategoryID { get; set; }
        public int InstructorID { get; set; }

        //Area
        [Display(Name = "Dublin Area")]
        [Required(ErrorMessage = "Please enter area")]
        public string DublinArea { get; set; }
        //public SelectAreaDublin? SelectAreaDublin { get; set; }

        //Class type
        [Display(Name = "Class Name")]
        [Required(ErrorMessage = "Please enter class type")]
        public string ClassName {get; set;}
        //public SelectClass? SelectClass { get; set; }

        //Gym Name
        [Display(Name = "Gym Name")]
        [Required(ErrorMessage = "Please type your gym name")]
        public string GymName { get; set; }

        //Description
        [DisplayFormat(NullDisplayText = "Contact us for more details")]
        [StringLength(10000), Display(Name = "Class Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //Start date
        [DataType(DataType.Date), Display(Name = "Start Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        //Start Time
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }

        //Capacity
        [Display(Name = "Maximum Enrollment")]
        //[Range(1, 15, ErrorMessage = "Enrollment ranges from 1 to max 20")]
        public int MaxEnroll { get; set; }

        //Status
        public Status? Status { get; set; }

        public virtual ICollection<RegistrationRecord> Records { get; set; }

    }
}