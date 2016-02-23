using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassFinderMVC.Models
{
    //***FitnessClassModel contains 5 classes 
    //***1.Category 2. ClassSchedule 3.Participant 4.Instructor 5.RegisterRecord ***


    // 1. Category Class
    public enum SelectCategory
    {
        [Display (Name = "Cardio Training")]
        CardioTraining,
        [Display(Name = "Yoga Pilates")]
        YogaPilates,
        [Display(Name = "Power Training")]
        PowerTraining
    }
    public class Category
    {
        [Key]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
        public int CategoryID { get; set; }

        [Required, Display(Name = "Fitness Category")]
        public SelectCategory SelectCategory { get; set; }

        [Display(Name = "Class Description")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Description range from 10 to 250 characters")]
        public string Description { get; set; }

        public virtual ICollection<ClassSchedule> Schdules { get; set; }
    }

    // 2. ClassSchedule Class
    public enum SelectArea { Dublin, Galway, Cork, Limerick }
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

        //Class Name
        [Required, StringLength(25), Display(Name = "Class Name")]
        public string ClassName { get; set; }

        //Description
        [Required, StringLength(10000), Display(Name = "Class Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //Start date
        private DateTime startDate = DateTime.Now;
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime StartDate { get { return startDate; } set { startDate = value; } }

        //Start Time
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        public string Duration { get; set; }

        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }

    // 3. Instructor

    public class Instructor
    {
        [Key]
        [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
        public int InstructorID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your location e.g. Dublin")]
        [StringLength(20, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

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

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your location e.g. Dublin")]
        [StringLength(20, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public string Status { get; set; }

        public int? RecordID { get; set; }
        public virtual ICollection<RegistrationRecord> Records { get; set; }
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

        public virtual ICollection<ClassSchedule> Schdules { get; set; }
    }

    public class FitnessDBContext : DbContext
    {
        public FitnessDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer<FitnessDBContext>(new DropCreateDatabaseIfModelChanges<FitnessDBContext>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClassSchedule> Schedules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<RegistrationRecord> Records { get; set; }

    }
}