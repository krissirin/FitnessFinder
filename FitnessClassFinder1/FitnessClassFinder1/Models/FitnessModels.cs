using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder1.Models
{
    //***FitnessModels contain 4 classes 
    //***1.Schedule 2.Participant 3.Instructor 4.Record ***

    //// 1. Schedule 
    //public enum SelectCounty { Dublin, Galway, Cork, Limerick }

    //public enum SelectAreaDublin
    //{
    //    Balbriggan,Citywest,Clondalkin,Clonskeagh,Donabate,Drumcondra, [Display(Name = "Dublin City Centre")]
    //    DublinCityCentre, [Display(Name = "Dun Laoghaire")]DunLaoghaire,Dundrum,Fairview,Fingal,Finglas,Glasnevin, [Display(Name = "Grand Canal Dock")]
    //    GrandCanalDock, [Display(Name = "Harold's Cross")]HaroldsCross,	Killiney,Lucan,Malahide,Millstown,Monkstown, [Display(Name = "Phoenix Park")]
    //    PhoenixPark,Raheny,Ranelagh,Rathfarnham,Rathmines,Ringsend,Sandymount,Smithfield,Stillorgan,Swords,Tallaght, [Display(Name = "Temple Bar")]
    //    TempleBar,Terenure
    //}
    //public enum SelectClass {Abs, Aerobics, [Display(Name = "Body Sculpt")] BodySculpt, Bootcamp, Boxing, Circuits,
    //    [Display(Name = "Core Training")]CoreTraining,
    //    [Display(Name = "Cross-Fit")]CrossFit, HIIT, Kettlebells, Kickboxing,
    //    [Display(Name = "Personal Training")] PersonalTraining, Pilates, Spinning, Step, Swimming, TRX,
    //    [Display(Name = "Weight Training")]WeightTraining, Yoga, Zumba
    //}
    //public class Schedule
    //{
    //    //PK Fitness Class ID
    //    [Key]
    //    public int FitnessClassID { get; set; }

    //    //Location
    //    [Display(Name = "Location")]
    //    [Required(ErrorMessage = "Please select county")]
    //    public SelectCounty SelectCounty { get; set; }

    //    //Area
    //    [Display(Name = "Area")]
    //    [Required(ErrorMessage = "Please select area")]
    //    public SelectAreaDublin SelectAreaDublin { get; set; }

    //    //Class type
    //    [Display(Name = "Class Type")]
    //    [Required(ErrorMessage = "Please select class type")]
    //    public SelectClass SelectClass { get; set; }

    //    //Gym Name
    //    [Display(Name = "Gym Name")]
    //    [Required(ErrorMessage = "Please type your gym name")]
    //    public string GymName { get; set; }

    //    //Description
    //    [DisplayFormat(NullDisplayText = "No description")]
    //    [StringLength(10000), Display(Name = "Class Description"), DataType(DataType.MultilineText)]
    //    public string Description { get; set; }

    //    //Start date
    //    private DateTime startDate = DateTime.Now;
    //    [Display(Name = "Start Date")]
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    //    public DateTime StartDate { get { return startDate; } set { startDate = value; } }

    //    //Start Time
    //    [Display(Name = "Start Time")]
    //    public string StartTime { get; set; }

    //    //Duration
    //    [DisplayFormat(NullDisplayText = "No duration")]
    //    public string Duration { get; set; }

    //    //Status
    //    [DisplayFormat(NullDisplayText = "No status")]
    //    public string Status { get; set; }

    //    //Maximum Enrollment
    //    [Display(Name = "Maximum Enrollment")]
    //    [Range(1, 20, ErrorMessage = "Enrollment ranges from 1 to 20")]
    //    public int MaxEnroll { get; set; }

    //    public virtual ICollection<RegistrationRecord> Records { get; set; }
    //    public virtual ICollection<Instructor> Instructors { get; set; }
    //}

    // 3. Instructor

    //public class Instructor
    //{
    //    [Key]
    //    public int InstructorID { get; set; }

    //    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    //    [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
    //    [Display(Name = "First Name")]
    //    public string FirstName { get; set; }

    //    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    //    [Display(Name = "Last Name")]
    //    [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters")]
    //    public string LastName { get; set; }

    //    [StringLength(100, ErrorMessage = "Address is too long")]
    //    public string Address { get; set; }

    //    [Required(AllowEmptyStrings = false)]
    //    [DataType(DataType.EmailAddress)]
    //    [Display(Name = "Email")]
    //    [EmailAddress]
    //    public string EmailAddress { get; set; }

    //    [DataType(DataType.Date)]
    //    [Display(Name = "Hire Date")]
    //    [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
    //    public DateTime HireDate { get; set; }

    //    [DisplayFormat(NullDisplayText = "No status")]
    //    public string Status { get; set; }

    //    public int? FitnessClassID { get; set; }
    //    public virtual ICollection<Schedule> Schedules { get; set; }
    //}

    //// 3. Participant

    //public class Participant
    //{
    //    [Key]
    //    [Required(ErrorMessage = "Enter an integer between 0 and 99999")]
    //    public int ParticipantID { get; set; }

    //    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    //    [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
    //    [Display(Name = "First Name")]
    //    public string FirstName { get; set; }

    //    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
    //    [Display(Name = "Last Name")]
    //    [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters")]
    //    public string LastName { get; set; }

    //    [Required(ErrorMessage = "Please enter your address")]
    //    [StringLength(100, ErrorMessage = "Address is too long")]
    //    public string Address { get; set; }

    //    [Required(AllowEmptyStrings = false)]
    //    [DataType(DataType.EmailAddress)]
    //    [Display(Name = "Email")]
    //    [EmailAddress]
    //    public string EmailAddress { get; set; }

    //    [DataType(DataType.Date)]
    //    [Display(Name = "Enrollment Date")]
    //    [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
    //    public DateTime EnrollmentDate { get; set; }

    //    public string Status { get; set; }

    //    public int? RecordID { get; set; }
    //    public virtual RegistrationRecord Records { get; set; }
    //    public virtual ICollection<Schedule> Schedules { get; set; }
    //}

    // 5. RegisterRecord Class

    //public class RegistrationRecord
    //{
    //    [Key]
    //    public int RecordID { get; set; }

    //    public int FitnessClassID { get; set; }

    //    public int ParticipantID { get; set; }

    //    [Display(Name = "Registration Date")]
    //    [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
    //    public DateTime RegistraionDate { get; set; }

    //    public string Status { get; set; }

    //    public virtual ICollection<Schedule> Schedules { get; set; }
    //}

    public class FitnessDBContext : DbContext
    {
        public FitnessDBContext() : base("DefaultConnection")
        {
            Database.SetInitializer<FitnessDBContext>(new DropCreateDatabaseIfModelChanges<FitnessDBContext>());
        }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<RegistrationRecord> Records { get; set; }

        //public System.Data.Entity.DbSet<FitnessClassFinder1.Models.RoleViewModel> RoleViewModels { get; set; }

        //public System.Data.Entity.DbSet<FitnessClassFinder1.Models.EditUserViewModel> EditUserViewModels { get; set; }
    }
}