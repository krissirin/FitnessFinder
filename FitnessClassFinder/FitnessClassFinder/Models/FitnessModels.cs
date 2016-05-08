using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder.Models
{
    //***FitnessModels contain 5 classes 
    //***1.Category 2. ClassSchedule 3.Participant 4.Instructor 5.RegisterRecord ***

    // 1. Category Class
    public enum SelectCategory
    {
        [Display(Name = "Cardio Training")]
        CardioTraining,
        [Display(Name = "Yoga Pilates")]
        YogaPilates,
        [Display(Name = "Power Training")]
        PowerTraining,
        [Display(Name = "Personal Training")]
        PersonalTraining,
        [Display(Name = "Martial Arts")]
        MartialArts,
        [Display(Name = "Self Defence")]
        SelfDefence
    }
    public class Category
    {
        [Key]
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
        public int CategoryID { get; set; }

        [Required, Display(Name = "Fitness Category")]
        public SelectCategory SelectCategory { get; set; }

        [Display(Name = "Category")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description range from 10 to 250 characters")]
        public string CategoryDescription { get; set; }

        public virtual ICollection<ClassSchedule> Schedules { get; set; }
    }

    // 2. ClassSchedule Class
    public enum SelectArea { Dublin, Galway, Cork, Limerick }
    public enum StartTime
    {
        [Display(Name = "6:00 AM")]
        AM0600 = 0600,
        [Display(Name = "6:30 AM")]
        AM0630 = 0630,
        [Display(Name = "7:00 AM")]
        AM0700 = 0700,
        [Display(Name = "7:30 AM")]
        AM0730 = 0730,
        [Display(Name = "8:00 AM")]
        AM0800 = 0800,
        [Display(Name = "8:30 AM")]
        AM0830 = 0830,
        [Display(Name = "9:00 AM")]
        AM0900 = 0900,
        [Display(Name = "9:30 AM")]
        AM0930 = 0930,
        [Display(Name = "10:00 AM")]
        AM1000 = 1000,
        [Display(Name = "10:30 AM")]
        AM1030 = 1030,
        [Display(Name = "11:00 AM")]
        AM1100 = 1100,
        [Display(Name = "11:30 AM")]
        AM1130 = 1130,
        [Display(Name = "12:00 AM")]
        AM1200 = 1200,
        [Display(Name = "1:00 PM")]
        PM1300 = 1300,
        [Display(Name = "1:30 PM")]
        PM1330 = 1330,
        [Display(Name = "2:00 PM")]
        PM1400 = 1400,
        [Display(Name = "2:30 PM")]
        PM1430 = 1430,
        [Display(Name = "3:00 PM")]
        PM1500 = 1500,
        [Display(Name = "3:30 PM")]
        PM1530 = 1530,
        [Display(Name = "4:00 PM")]
        PM1600 = 1600,
        [Display(Name = "4:30 PM")]
        PM1630 = 1630,
        [Display(Name = "5:00 PM")]
        PM1700 = 1700,
        [Display(Name = "5:30 PM")]
        PM1730 = 1730,
        [Display(Name = "6:00 PM")]
        PM1800 = 1800,
        [Display(Name = "6:30 PM")]
        PM1830 = 1830,
        [Display(Name = "7:00 PM")]
        PM1900 = 1900,
        [Display(Name = "7:30 PM")]
        PM1930 = 1930,
        [Display(Name = "8:00 PM")]
        PM2000 = 2000,
        [Display(Name = "8:30 PM")]
        PM2030 = 2030,
        [Display(Name = "9:00 PM")]
        PM2100 = 2100,
    }
    public enum Duration
    {
        [Display(Name = "30 Minutes")]
        ThirtyMinute,
        [Display(Name = "45 Minutes")]
        FortyFiveMinute,
        [Display(Name = "50 Minutes")]
        FiftyMinute,
        [Display(Name = "60 Minutes")]
        SixtyMinute,
        [Display(Name = "90 Minutes")]
        NinetyMinute
    }
    public enum Status { Available, [Display(Name = "Fully Booked")] Fullybooked }
    public class ClassSchedule
    {
        //PK Fitness Class ID
        [Key]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
        public int FitnessClassID { get; set; }

        //Location
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please select location")]
        public SelectArea SelectArea { get; set; }

        //LocalArea
        [Display(Name = "Area")]
        public string LocalArea { get; set; }

        //Class Name
        [Required, StringLength(25), Display(Name = "Class Name")]
        public string ClassName { get; set; }

        //Description
        [Required, StringLength(10000), Display(Name = "Class Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //Gym Name
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        //Start date
        private DateTime startDate = DateTime.Now;
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }

        //Start Time
        [Display(Name = "Start Time")]
        public StartTime StartTime { get; set; }

        //Duration
        public Duration Duration { get; set; }

        //Status
        public Status Status { get; set; }

        //Maximum Enrollment
        [Display(Name = "Capacity")]
        [Range(1, 20, ErrorMessage = "Enrollment ranges from 1 to 20")]
        public int MaxEnroll { get; set; }

        //Fee
        [Display(Name = "Deposit")]
        [DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Fee { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<RegistrationRecord> Records { get; set; }
    }

    // 3. Instructor

    public class Instructor
    {
        [Key]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
        public int InstructorID { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [Display(Name = "Fitness Location")]
        [Required(ErrorMessage = "Please enter your location e.g. Dublin")]
        [StringLength(20, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        //[EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        public string Phone { get; set; }

        [Display(Name = "Fitness Class Taught")]
        public string Status { get; set; }

        public int? FitnessClassID { get; set; }
        public virtual ICollection<ClassSchedule> Schedules { get; set; }
    }

    // 3. Participant

    public class Participant
    {
        [Key]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
        public int ParticipantID { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your location e.g. Dublin")]
        [StringLength(50, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Display(Name = "Contact Number")]
        //public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        //public string Status { get; set; }

        public int? RecordID { get; set; }
        public virtual RegistrationRecord Records { get; set; }
        public virtual ICollection<ClassSchedule> Schedules { get; set; }
    }

    // 5. RegisterRecord Class

    public class RegistrationRecord
    {
        [Key]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999.")]
        public int RecordID { get; set; }

        [Required(ErrorMessage = "Enter an integer between 0 and 99999.")]
        public int FitnessClassID { get; set; }

        [Required(ErrorMessage = "Enter an integer between 0 and 99999.")]
        public int ParticipantID { get; set; }

        [Display(Name = "Registration Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistraionDate { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<ClassSchedule> Schedules { get; set; }
    }
}