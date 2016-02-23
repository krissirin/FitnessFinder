using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ClassFinderMVC.Models
{
    //*********************************************************************//
    //               Set DB context and initializer classes                //
    //*********************************************************************//

    //public class FitnessClassContext : DbContext
    //{
    //    public FitnessClassContext() : base("DefaultConnection")
    //    {
    //        Database.SetInitializer<FitnessClassContext>(new DropCreateDatabaseIfModelChanges<FitnessClassContext>());
    //    }
    //    public DbSet<Category> Categories { get; set; }
    //    public DbSet<ClassSchedule> Schedules { get; set; }
    //    public DbSet<Instructor> Instructors { get; set; }
    //    public DbSet<Participant> Participants { get; set; }
    //    public DbSet<RegistrationRecord> Records { get; set; }

    //}

    // Set FitnessClass Repository
    public class FitnessRepository
    {
        public void AddCategory(Category c)
        {
            using (FitnessDBContext db = new FitnessDBContext())
            {
                try
                {
                    db.Categories.Add(c);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }

        public void AddSchedule(ClassSchedule schedule)
        {
            using (FitnessDBContext db = new FitnessDBContext())
            {
                try
                {
                    db.Schedules.Add(schedule);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }

        public void AddInstructor(Instructor instructor)
        {
            using (FitnessDBContext db = new FitnessDBContext())
            {
                try
                {
                    db.Instructors.Add(instructor);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }

        public void AddParticipant(Participant participant)
        {
            using (FitnessDBContext db = new FitnessDBContext())
            {
                try
                {
                    db.Participants.Add(participant);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }
        public void AddRecord(RegistrationRecord record)
        {
            using (FitnessDBContext db = new FitnessDBContext())
            {
                try
                {
                    db.Records.Add(record);
                    db.SaveChanges();
                }
                catch (Exception e)
                { Console.WriteLine(e.ToString()); }
            }
        }

        //*****************  CODE FIRST TEST *****************//

        public class FitnessClassModelTest
        {
            static void main()
            {
                FitnessDBContext db = new FitnessDBContext();
                //Category Class Test
                List<Category> categories = new List<Category>();
                categories.Add(new Category() { CategoryID = 1, SelectCategory = SelectCategory.CardioTraining, Description = "We offer a wide range of cardio exercise from low to high intensity.", Schdules = new List<ClassSchedule>() });
                categories.Add(new Category() { CategoryID = 2, SelectCategory = SelectCategory.YogaPilates, Description = "Your home for Yoga and Pilates classes. Classes are accessible for all levels and abilities", Schdules = new List<ClassSchedule>() });
                categories.Add(new Category() { CategoryID = 3, SelectCategory = SelectCategory.PowerTraining, Description = "Explosive exercise training builds power, strength and fitness fast.", Schdules = new List<ClassSchedule>() });

                //ClassSchedule Class Test
                List<ClassSchedule> schedules = new List<ClassSchedule>();
                schedules.Add(new ClassSchedule() { FitnessClassID = 1, SelectArea = SelectArea.Dublin, ClassName = "Zumba", Description = "One of the most effective ways to get fit, lose weight, strengthen muscles and increase flexibility", StartDate = DateTime.Parse("09/05/2016"), StartTime = "9am", Duration = "40 minutes", CategoryID = 1 });
                schedules.Add(new ClassSchedule() { FitnessClassID = 2, SelectArea = SelectArea.Galway, ClassName = "Pilates", Description = "targets the deep postural muscles within the body through a series of exercises aimed at building muscle strength and rebalancing the body", StartDate = DateTime.Parse("12/05/2016"), StartTime = "6pm", Duration = "60 minutes", CategoryID = 2 });
                schedules.Add(new ClassSchedule() { FitnessClassID = 3, SelectArea = SelectArea.Limerick, ClassName = "Cross-Fit", Description = "CrossFit is an intense exercise program featuring dynamic exercises like plyometric jumps, and Olympic lifts while using non-traditional weightlifting equipment such as kettlbells, sand-bags, suspension systems or water-filled implements.", StartDate = DateTime.Parse("13/05/2016"), StartTime = "5pm", Duration = "45 minutes",CategoryID = 3 });
                 
                //Instructor Test
                List<Instructor> instructors = new List<Instructor>();
                instructors.Add(new Instructor() { InstructorID = 101, FirstName = "Frank", LastName = "Borat", Address = "Dublin", Email = "frankborat@gmail.com", HireDate = DateTime.Parse("15/04/2016"), Status = "", FitnessClassID = 1, Schedules = new List<ClassSchedule>() });

                //Participant Test
                List<Participant> participants = new List<Participant>();
                participants.Add(new Participant() { ParticipantID = 202, FirstName = "Sarah", LastName = "Thompsons", Address = "Dublin", Email = "sarahthompsons@gmail.com", EnrollmentDate = DateTime.Parse("20/04/2016"), Status = "", RecordID = 222, Records = new List<RegistrationRecord>() });
                participants.Add(new Participant() { ParticipantID = 203, FirstName = "Jane", LastName = "Doyles", Address = "Galway", Email = "janedoyles@gmail.com", EnrollmentDate = DateTime.Parse("23/04/2016"), Status = "", RecordID = 223, Records = new List<RegistrationRecord>() });


                //RegistrationRecord Class Test
                List<RegistrationRecord> records = new List<RegistrationRecord>();
                records.Add(new RegistrationRecord() { RecordID = 1, FitnessClassID = 1, ParticipantID = 202, Status = "", Schdules = new List<ClassSchedule>() });
                records.Add(new RegistrationRecord() { RecordID = 2, FitnessClassID = 2, ParticipantID = 203, Status = "", Schdules = new List<ClassSchedule>() });


                Category cc = new Category() { CategoryID = 1, SelectCategory = SelectCategory.CardioTraining, Description = "We offer a wide range of cardio exercise from low to high intensity.", Schdules = new List<ClassSchedule>() };

            }
        }
    }
}