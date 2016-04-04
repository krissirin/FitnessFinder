using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FitnessStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<FitnessContext>
    {
        protected override void Seed(FitnessContext context)
        {
            var participants = new List<Participant>
            {
                new Participant { Name = "Amy Williams",   Address = "Dublin City Centre", EmailAddress = "amywilliams@gmail.com", PhoneNumber = "0863654896" },
                new Participant { Name = "Bella Dyer",   Address = "Tallaght", EmailAddress = "belladyer@gmail.com", PhoneNumber = "0874562589" },
                new Participant { Name = "Peter Jones",   Address = "Dublin City Centre", EmailAddress = "peterjones@gmail.com", PhoneNumber = "0855693558" },
                new Participant { Name = "Connor T",   Address = "Tallaght", EmailAddress = "connort34@gmail.com", PhoneNumber = "0866692588" },
                new Participant { Name = "David Harrisson",   Address = "Malahide", EmailAddress = "davidharrisson@gmail.com", PhoneNumber = "0862257894" },
                new Participant { Name = "Moloney",   Address = "Tallaght", EmailAddress = "armanymoloney@yahoo.com", PhoneNumber = "0897445682" },
                new Participant { Name = "Ella Gavinda",   Address = "Temple Bar", EmailAddress = "ella1980@gmail.com", PhoneNumber = "0865521347" },
                new Participant { Name = "Frank L",   Address = "Dundrum", EmailAddress = "frankabc123@gmail.com", PhoneNumber = "0874582231" },
                new Participant { Name = "Jacob B",   Address = "Citywest", EmailAddress = "jacobwestpa@yahoo.com", PhoneNumber = "0863328875" },
                new Participant { Name = "Phil Dunnes",   Address = "Raheny", EmailAddress = "philly444@gmail.com", PhoneNumber = "0833254487" },
                new Participant { Name = "Robert Thompson",   Address = "Dundrum", EmailAddress = "roberttmp@gmail.com", PhoneNumber = "0895562545" },
                new Participant { Name = "Sarah Young",   Address = "Temple Bar", EmailAddress = "sarahyoung@gmail.com", PhoneNumber = "0833657894" },
                new Participant { Name = "Susie Doherty",   Address = "Rathmines", EmailAddress = "susiedoherty@gmail.com", PhoneNumber = "0861397998" },
                new Participant { Name = "Vanessa D",   Address = "Dublin City Centre", EmailAddress = "vanessaday@gmail.com", PhoneNumber = "0855641125" },
                new Participant { Name = "Wendy Scott",   Address = "Tallaght", EmailAddress = "wendyscott@gmail.com", PhoneNumber = "0874581236" }
            };
            context.SaveChanges();

            var classtypes = new List<ClassType>
            {
                new ClassType { SelectClass = SelectClass.Abs, Description = "This is a 30 minute class of hardcore abdominal work. It focuses on toning and defining the abs and strengthening." },
                new ClassType { SelectClass = SelectClass.AquaAerobics, Description = "Aqua aerobic is a low-impact form of resistance training which is great for improving both cardiovascular fitness and toning muscles" },
                new ClassType { SelectClass = SelectClass.BodySculpt, Description = "Body sculpting is a non-aerobic, muscle-toning class, usually focused on core strength." },
                new ClassType { SelectClass = SelectClass.Bootcamp, Description = " A fitness boot camp is type of outdoor group exercise class that mixes traditional calisthenic and body weight exercises with interval training and strength training." },
                new ClassType { SelectClass = SelectClass.Boxing, Description = "This class is a combination of cardio, boxing and marital arts providing a total body workout which aims to improve strength, aerobic fitness, speed and flexibility." },
                new ClassType { SelectClass = SelectClass.Circuits, Description = "Circuit training is a fast-paced class in which you do one exercise for 30 seconds to 5 minutes and then move on to another exercise." },
                new ClassType { SelectClass = SelectClass.CoreTraining, Description = "Core conditioning is a non-aerobic, muscle-toning class, usually focused on core strength." },
                new ClassType { SelectClass = SelectClass.CrossFit, Description = "CrossFit gyms use equipment from multiple disciplines, including barbells, dumbbells, gymnastics rings, pull-up bars, jump ropes, kettlebells, medicine balls and etc." },
                new ClassType { SelectClass = SelectClass.HIIT, Description = " HIIT or High Intensity Interval Training is  a total body, heart pumping, aerobic and strength conditioning workout." },
                new ClassType { SelectClass = SelectClass.Kettlebells, Description = " is a cast-iron or cast steel weight, perform ballistic exercises that combine cardiovascular, strength and flexibility training." },
                new ClassType { SelectClass = SelectClass.Kickboxing, Description = "A Combination of Dance and Kickboxing moves; Cardio aerobic activity; put together to heart pounding high energy music." },
                new ClassType { SelectClass = SelectClass.PersonalTraining, Description = "For full details on personal training costs, please contact us directly with your query. Gift vouchers available on request." },
                new ClassType { SelectClass = SelectClass.Pilates, Description = "Pilates is a system of controlled exercises that engage the mind and condition the total body." },
                new ClassType { SelectClass = SelectClass.Spinning, Description = "Cycling Classes at Defined Fitness build endurance, strengthen your core, tone your muscles and make for the perfect cardio workout." },
                new ClassType { SelectClass = SelectClass.Step, Description = "BODYSTEP, full-body cardio workout to tone your butt and thighs - Find a class near you." },
                new ClassType { SelectClass = SelectClass.Swimming, Description = "We offer one on one private swimming lessons at affordable prices for all levels." },
                new ClassType { SelectClass = SelectClass.TRX, Description = "Take bodyweight training to new heights with TRX Suspension Training. All levels, all goals, all core, all the time." },
                new ClassType { SelectClass = SelectClass.WeightTraining, Description = "Weight training is a common type of strength training for developing the strength and size of skeletal muscles." },
                new ClassType { SelectClass = SelectClass.Yoga, Description = "We are pleased to offer a variety of yoga classes and styles for all students and all levels." },
                new ClassType { SelectClass = SelectClass.Zumba, Description = "Zumba® Fitness is a feel-happy workout that combines a motivating fusion of Latin and international." },

            };
            context.SaveChanges();


            var instructors = new List<Instructor>
            {
                new Instructor { Name = "Aronda Copland", EmailAddress = "arondacop@gmail.com", PhoneNumber ="0871354896"},
                new Instructor { Name = "Adrian Leaper", EmailAddress = "adrainlea@gmail.com", PhoneNumber ="0871354888" },
                new Instructor { Name = "Billy Cobham", EmailAddress = "billycobham@gmail.com", PhoneNumber ="0861354813" }, 
                new Instructor { Name = "Britten Sonia", EmailAddress = "brittensoni@gmail.com", PhoneNumber ="0851354888" },
                new Instructor { Name = "Chris Cornell", EmailAddress = "chriscornell@gmail.com", PhoneNumber ="0851454828" },
                new Instructor { Name = "Ciaron Doyles", EmailAddress = "ciarond@gmail.com", PhoneNumber ="0851854688" },
                new Instructor { Name = "Chris Cornell", EmailAddress = "chriscornell@gmail.com", PhoneNumber ="0851854528" },
                new Instructor { Name = "Declan Hayes", EmailAddress = "declanhayes@gmail.com", PhoneNumber ="0865854896" },
                new Instructor { Name = "Donald Sams", EmailAddress = "donaldsams@gmail.com", PhoneNumber ="0831254999" },
                new Instructor { Name = "Eric Dunnes", EmailAddress = "eric@gmail.com", PhoneNumber ="0861354563" },
                new Instructor { Name = "Frank Zappa", EmailAddress = "frankzappa@gmail.com", PhoneNumber ="0851312387" },
                new Instructor { Name = "Gerald Moore", EmailAddress = "geraldmoore@gmail.com", PhoneNumber ="0851853218" },
                new Instructor { Name = "Michael Thomas", EmailAddress = "michaelthomas@gmail.com", PhoneNumber ="0832854688" },
                new Instructor { Name = "Paul Tracey", EmailAddress = "paultracey@gmail.com", PhoneNumber ="0851854369" },

            };
            context.SaveChanges();

            var schedules = new List<Schedule>
            {
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Abs).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Aronda Copland").InstructorID, SelectAreaDublin = SelectAreaDublin.DublinCityCentre, ClassName = "Abs", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("09-05-2016"), StartTime = "5pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Abs).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Chris Cornell").InstructorID, SelectAreaDublin = SelectAreaDublin.TempleBar, ClassName = "Abs", GymName = "The Abs Gym", StartDate = DateTime.Parse("10-05-2016"), StartTime = "6pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Abs).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Declan Hayes").InstructorID, SelectAreaDublin = SelectAreaDublin.DublinCityCentre, ClassName = "Abs", GymName = "FLYEfit Gym", StartDate = DateTime.Parse("11-05-2016"), StartTime = "7pm", MaxEnroll = 20, Status = Status.Fullybooked },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.AquaAerobics).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Adrian Leaper").InstructorID, SelectAreaDublin = SelectAreaDublin.Malahide, ClassName = "Aqua Aerobics", GymName = "Arena Leisure Centre", StartDate = DateTime.Parse("12-05-2016"), StartTime = "9am", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.AquaAerobics).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Eric Dunnes").InstructorID, SelectAreaDublin = SelectAreaDublin.DunLaoghaire, ClassName = "Aqua Aerobics", GymName = "Loughlinstown Leisure Centre", StartDate = DateTime.Parse("09-05-2016"), StartTime = "10am", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.BodySculpt).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Michael Thomas").InstructorID, SelectAreaDublin = SelectAreaDublin.PhoenixPark, ClassName = "Body Sculpt", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("10-05-2016"), StartTime = "6pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Bootcamp).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Aronda Copland").InstructorID, SelectAreaDublin = SelectAreaDublin.DublinCityCentre, ClassName = "Bootcamp", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("11-05-2016"), StartTime = "7pm", MaxEnroll = 20, Status = Status.Fullybooked },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Boxing).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Billy Cobham").InstructorID, SelectAreaDublin = SelectAreaDublin.Malahide, ClassName = "Boxing", GymName = "Platinum Gyms", StartDate = DateTime.Parse("12-05-2016"), StartTime = "8pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Boxing).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Paul Tracey").InstructorID, SelectAreaDublin = SelectAreaDublin.Citywest, ClassName = "Boxing", GymName = "Westpark Fitness", StartDate = DateTime.Parse("09-05-2016"), StartTime = "6pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Circuits).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Aronda Copland").InstructorID, SelectAreaDublin = SelectAreaDublin.Raheny, ClassName = "Circuits", GymName = "Access Fitness", StartDate = DateTime.Parse("10-05-2016"), StartTime = "7pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.CoreTraining).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Aronda Copland").InstructorID, SelectAreaDublin = SelectAreaDublin.DunLaoghaire, ClassName = "Core Training", GymName = "Warriors Gym", StartDate = DateTime.Parse("11-05-2016"), StartTime = "5pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.CrossFit).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Michael Thomas").InstructorID, SelectAreaDublin = SelectAreaDublin.Tallaght, ClassName = "CrossFit", GymName = "Westpark Fitness", StartDate = DateTime.Parse("12-05-2016"), StartTime = "9am", MaxEnroll = 20, Status = Status.Fullybooked },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.CrossFit).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Billy Cobham").InstructorID, SelectAreaDublin = SelectAreaDublin.Dundrum, ClassName = "CrossFit", GymName = "Rock Fitness", StartDate = DateTime.Parse("09-05-2016"), StartTime = "5pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.HIIT).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Gerald Moore").InstructorID, SelectAreaDublin = SelectAreaDublin.Tallaght, ClassName = "HITT", GymName = "Westpark Fitness", StartDate = DateTime.Parse("10-05-2016"), StartTime = "6pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.HIIT).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Ciaron Doyles").InstructorID, SelectAreaDublin = SelectAreaDublin.Rathmines, ClassName = "HITT", GymName = "Swan Leisure", StartDate = DateTime.Parse("11-05-2016"), StartTime = "5pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Kettlebells).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Chris Cornell").InstructorID, SelectAreaDublin = SelectAreaDublin.Dundrum, ClassName = "Kettlebells", GymName = "Rock Fitness", StartDate = DateTime.Parse("12-05-2016"), StartTime = "10am", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Kettlebells).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Eric Dunnes").InstructorID, SelectAreaDublin = SelectAreaDublin.TempleBar, ClassName = "Kettlebells", GymName = "Crunch Fitness Temple Bar", StartDate = DateTime.Parse("13-05-2016"), StartTime = "9am", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Kickboxing).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Michael Thomas").InstructorID, SelectAreaDublin = SelectAreaDublin.DublinCityCentre, ClassName = "Kickboxing", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("09-05-2016"), StartTime = "5pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Swimming).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Paul Tracey").InstructorID, SelectAreaDublin = SelectAreaDublin.Tallaght, ClassName = "Swimming", GymName = "Westpark Fitness", StartDate = DateTime.Parse("13-05-2016"), StartTime = "6pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Yoga).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Declan Hayes").InstructorID, SelectAreaDublin = SelectAreaDublin.DublinCityCentre, ClassName = "Yoga", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("10-05-2016"), StartTime = "7pm", MaxEnroll = 20, Status = Status.Fullybooked },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Yoga).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Aronda Copland").InstructorID, SelectAreaDublin = SelectAreaDublin.Tallaght, ClassName = "Yoga", GymName = "Westpark Fitness", StartDate = DateTime.Parse("09-05-2016"), StartTime = "7pm", MaxEnroll = 20, Status = Status.Available },
                new Schedule {ClassTypeID = classtypes.Single(c => c.SelectClass == SelectClass.Zumba).ClassTypeID, InstructorID = instructors.Single(i => i.Name == "Frank Zappa").InstructorID, SelectAreaDublin = SelectAreaDublin.Tallaght, ClassName = "Zumba", GymName = "Westpark Fitness", StartDate = DateTime.Parse("13-05-2016"), StartTime = "7pm", MaxEnroll = 20, Status = Status.Fullybooked },
            };

            foreach (Schedule s in schedules)
            {
                var scheduleInDataBase = context.Schedules.Where(
                    c =>
                         c.ClassTypeID == s.ClassTypeID &&
                         c.InstructorID == s.InstructorID).SingleOrDefault();
                if (scheduleInDataBase == null)
                {
                    context.Schedules.Add(s);
                }
            }
            context.SaveChanges();

            var records = new List<RegistrationRecord>
            {
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "Abs").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "Amy Williams" ).ParticipantID, RegistraionDate = DateTime.Parse("10-04-2016"), Status = "Reserve" },
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "Boxing").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "David Harrisson" ).ParticipantID, RegistraionDate = DateTime.Parse("15-04-2016"), Status = "Reserve" },
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "Kickboxing").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "Peter Jones" ).ParticipantID, RegistraionDate = DateTime.Parse("17-04-2016"), Status = "Reserve" },
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "Kettlebells").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "Frank L" ).ParticipantID, RegistraionDate = DateTime.Parse("13-04-2016"), Status = "Reserve" },
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "CrossFit").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "Moloney" ).ParticipantID, RegistraionDate = DateTime.Parse("20-04-2016"), Status = "Reserve" },
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "Yoga").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "Bella Dyer" ).ParticipantID, RegistraionDate = DateTime.Parse("25-04-2016"), Status = "Reserve" },
                new RegistrationRecord {
                    ScheduleID = schedules.Single(s => s.ClassName == "Zumba").ScheduleID,
                    ParticipantID = participants.Single(c => c.Name == "Wendy Scott" ).ParticipantID, RegistraionDate = DateTime.Parse("12-04-2016"), Status = "Reserve" },

            };

            foreach (RegistrationRecord r in records)
            {
                var recordInDataBase = context.RegistrationRecords.Where(
                    s =>
                         s.ScheduleID == r.ScheduleID &&
                         s.ParticipantID == r.ParticipantID).SingleOrDefault();
                if (recordInDataBase == null)
                {
                    context.RegistrationRecords.Add(r);
                }
            }
            context.SaveChanges();
        }
    }
}
