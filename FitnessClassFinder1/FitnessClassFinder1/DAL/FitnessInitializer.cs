//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data.Entity;
//using FitnessClassFinder1.Models;

//namespace FitnessClassFinder1.DAL
//{
//    public class FitnessInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FitnessContext>
//    {
//        protected override void Seed(FitnessContext context)
//        {

//            var categories = new List<Category>
//            {
//                new Category { Name = "Abs", Description = "This is a 30 minute class of hardcore abdominal work. It focuses on toning and defining the abs and strengthening.", Schedules = new List <Schedule>(){} },
//                new Category { Name = "Aqua Aerobics", Description = "Aqua aerobic is a low-impact form of resistance training which is great for improving both cardiovascular fitness and toning muscles", Schedules = new List <Schedule>(){} },
//                new Category { Name = "Body Sculpt", Description = "Body sculpting is a non-aerobic, muscle-toning class, usually focused on core strength.", Schedules = new List <Schedule>(){}   },
//                new Category { Name = "Bootcamp", Description = " A fitness boot camp is type of outdoor group exercise class that mixes traditional calisthenic and body weight exercises with interval training and strength training.",  Schedules = new List <Schedule>(){} },
//                new Category { Name = "Boxing", Description = "This class is a combination of cardio, boxing and marital arts providing a total body workout which aims to improve strength, aerobic fitness, speed and flexibility.",  Schedules = new List <Schedule>(){} },
//                new Category { Name = "Circuits", Description = "Circuit training is a fast-paced class in which you do one exercise for 30 seconds to 5 minutes and then move on to another exercise.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Core Training", Description = "Core conditioning is a non-aerobic, muscle-toning class, usually focused on core strength.",  Schedules = new List <Schedule>(){} },
//                new Category { Name = "Cross-Fit", Description = "CrossFit gyms use equipment from multiple disciplines, including barbells, dumbbells, gymnastics rings, pull-up bars, jump ropes, kettlebells, medicine balls and etc.", Schedules = new List <Schedule>(){} },
//                new Category { Name = "HIIT", Description = " HIIT or High Intensity Interval Training is  a total body, heart pumping, aerobic and strength conditioning workout.",  Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Kettlebells", Description = " is a cast-iron or cast steel weight, perform ballistic exercises that combine cardiovascular, strength and flexibility training.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Kickboxing", Description = "A Combination of Dance and Kickboxing moves; Cardio aerobic activity; put together to heart pounding high energy music.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Personal Training",Description = "For full details on personal training costs, please contact us directly with your query. Gift vouchers available on request.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Pilates", Description = "Pilates is a system of controlled exercises that engage the mind and condition the total body.", Schedules = new List <Schedule>(){} },
//                new Category { Name = "Spinning", Description = "Cycling Classes at Defined Fitness build endurance, strengthen your core, tone your muscles and make for the perfect cardio workout.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Step", Description = "BODYSTEP, full-body cardio workout to tone your butt and thighs - Find a class near you.", Schedules = new List <Schedule>(){} },
//                new Category { Name = "Swimming", Description = "We offer one on one private swimming lessons at affordable prices for all levels.", Schedules = new List <Schedule>(){}   },
//                new Category { Name = "TRX", Description = "Take bodyweight training to new heights with TRX Suspension Training. All levels, all goals, all core, all the time.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Weight Training", Description = "Weight training is a common type of strength training for developing the strength and size of skeletal muscles.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Yoga", Description = "We are pleased to offer a variety of yoga classes and styles for all students and all levels.", Schedules = new List <Schedule>(){}  },
//                new Category { Name = "Zumba", Description = "Zumba® Fitness is a feel-happy workout that combines a motivating fusion of Latin and international.", Schedules = new List <Schedule>(){}  }
//            };

//            var participants = new List<Participant>
//            {
//                new Participant { FirstName = "Amy Williams", LastName = "Williams", Address = "Dublin City Centre", EmailAddress = "amywilliams@gmail.com", PhoneNumber = "0863654896" },
//                new Participant { FirstName = "Bella", LastName = "Dyer", Address = "Tallaght", EmailAddress = "belladyer@gmail.com", PhoneNumber = "0874562589" },
//                new Participant { FirstName = "Peter", LastName = "Jones", Address = "Dublin City Centre", EmailAddress = "peterjones@gmail.com", PhoneNumber = "0855693558" },
//                new Participant { FirstName= "Connor", LastName = "Tolle", Address = "Tallaght", EmailAddress = "connort34@gmail.com", PhoneNumber = "0866692588" },
//                new Participant { FirstName = "David", LastName = "Harrisson", Address = "Malahide", EmailAddress = "davidharrisson@gmail.com", PhoneNumber = "0862257894" },
//                new Participant { FirstName = "Jason", LastName = "Mooney", Address = "Tallaght", EmailAddress = "armanymoloney@yahoo.com", PhoneNumber = "0897445682" },
//                new Participant { FirstName = "Ella", LastName = "Gavinda", Address = "Temple Bar", EmailAddress = "ella1980@gmail.com", PhoneNumber = "0865521347" },
//                new Participant { FirstName = "Frank", LastName = "Clarke", Address = "Dundrum", EmailAddress = "frankabc123@gmail.com", PhoneNumber = "0874582231" },
//                new Participant { FirstName = "Jacob", LastName = "Holy", Address = "Citywest", EmailAddress = "jacobwestpa@yahoo.com", PhoneNumber = "0863328875" },
//                new Participant { FirstName = "Phil", LastName = "Dunnes", Address = "Raheny", EmailAddress = "philly444@gmail.com", PhoneNumber = "0833254487" },
//                new Participant { FirstName = "Robert", LastName = "Thompson", Address = "Dundrum", EmailAddress = "roberttmp@gmail.com", PhoneNumber = "0895562545" },
//                new Participant { FirstName = "Sarah", LastName = "Young", Address = "Temple Bar", EmailAddress = "sarahyoung@gmail.com", PhoneNumber = "0833657894" },
//                new Participant { FirstName = "Susie", LastName = "Doherty", Address = "Rathmines", EmailAddress = "susiedoherty@gmail.com", PhoneNumber = "0861397998" },
//                new Participant { FirstName = "Vanessa", LastName = "May", Address = "Dublin City Centre", EmailAddress = "vanessaday@gmail.com", PhoneNumber = "0855641125" },
//                new Participant { FirstName = "Wendy",LastName = "Scott", Address = "Tallaght", EmailAddress = "wendyscott@gmail.com", PhoneNumber = "0874581236" },
//                new Participant { FirstName = "William",LastName = "Grey", Address = "Tallaght", EmailAddress = "williamgrey@gmail.com", PhoneNumber = "0863281195" }

//            };
//            participants.ForEach(s => context.Participants.Add(s));
//            context.SaveChanges();

//            var instructors = new List<Instructor>
//            {
//                new Instructor { FirstName = "Aronda", LastName = "Copland", EmailAddress = "arondacop@gmail.com", PhoneNumber ="0871354896"},
//                new Instructor { FirstName = "Adrian", LastName = "Leaper", EmailAddress = "adrainlea@gmail.com", PhoneNumber ="0871354888" },
//                new Instructor { FirstName = "Billy", LastName = "Cobham", EmailAddress = "billycobham@gmail.com", PhoneNumber ="0861354813" },
//                new Instructor { FirstName = "Britten Sonia", EmailAddress = "brittensoni@gmail.com", PhoneNumber ="0851354888" },
//                new Instructor { FirstName = "Chris", LastName = "Cornell", EmailAddress = "chriscornell@gmail.com", PhoneNumber ="0851454828" },
//                new Instructor { FirstName = "Ciaron", LastName = "Doyles", EmailAddress = "ciarond@gmail.com", PhoneNumber ="0851854688" },
//                new Instructor { FirstName = "Christopher", LastName = "Smith", EmailAddress = "christophersmith@gmail.com", PhoneNumber ="0851854528" },
//                new Instructor { FirstName = "Declan", LastName = "Hayes", EmailAddress = "declanhayes@gmail.com", PhoneNumber ="0865854896" },
//                new Instructor { FirstName = "Donald Sams", LastName = "Sams", EmailAddress = "donaldsams@gmail.com", PhoneNumber ="0831254999" },
//                new Instructor { FirstName = "Eric", LastName = "Dunnes", EmailAddress = "eric@gmail.com", PhoneNumber ="0861354563" },
//                new Instructor { FirstName = "Frank", LastName = "Liamson", EmailAddress = "frankliamson@gmail.com", PhoneNumber ="0851312387" },
//                new Instructor { FirstName = "Gerald", LastName = "Moore", EmailAddress = "geraldmoore@gmail.com", PhoneNumber ="0851853218" },
//                new Instructor { FirstName = "Michael", LastName = "Thomas", EmailAddress = "michaelthomas@gmail.com", PhoneNumber ="0832854688" },
//                new Instructor { FirstName = "Paul",  LastName = "Tracey", EmailAddress = "paultracey@gmail.com", PhoneNumber ="0851854369" },

//            };
//            instructors.ForEach(s => context.Instructors.Add(s));
//            context.SaveChanges();

//            var schedules = new List<Schedule>
//            {

//                new Schedule {CategoryID = categories.Single(c => c.Name == "Abs").CategoryID, ClassName = "Abs", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Aronda").InstructorID, DublinArea = "DublinCityCentre", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("09-05-2016"), StartTime = "5pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){}   },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Abs").CategoryID, ClassName = "Abs", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Chris").InstructorID, DublinArea = "TempleBar", GymName = "The Abs Gym", StartDate = DateTime.Parse("10-05-2016"), StartTime = "6pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Abs").CategoryID, ClassName = "Abs", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Declan").InstructorID, DublinArea = "DublinCityCentre", GymName = "FLYEfit Gym", StartDate = DateTime.Parse("11-05-2016"), StartTime = "7pm", MaxEnroll = 15, Status = Status.Fullybooked, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "AquaAerobics").CategoryID, ClassName = "AquaAerobics", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Adrian").InstructorID, DublinArea = "Malahide", GymName = "Arena Leisure Centre", StartDate = DateTime.Parse("12-05-2016"), StartTime = "9am", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "AquaAerobics").CategoryID, ClassName = "AquaAerobics", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Eric").InstructorID, DublinArea = "DunLaoghaire", GymName = "Loughlinstown Leisure Centre", StartDate = DateTime.Parse("09-05-2016"), StartTime = "10am", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "BodySculpt").CategoryID, ClassName = "BodySculpt", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Michael").InstructorID, DublinArea = "PhoenixPark", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("10-05-2016"), StartTime = "6pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Bootcamp").CategoryID, ClassName = "Bootcamp", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Aronda").InstructorID, DublinArea = "DublinCityCentre", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("11-05-2016"), StartTime = "7pm", MaxEnroll = 15, Status = Status.Fullybooked, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Boxing").CategoryID, ClassName = "Boxing", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Billy").InstructorID, DublinArea = "Malahide", GymName = "Platinum Gyms", StartDate = DateTime.Parse("12-05-2016"), StartTime = "8pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Boxing").CategoryID, ClassName = "Boxing", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Paul").InstructorID, DublinArea = "Citywest",  GymName = "Westpark Fitness", StartDate = DateTime.Parse("09-05-2016"), StartTime = "6pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Circuits").CategoryID, ClassName = "Circuits", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Aronda").InstructorID, DublinArea = "Raheny", GymName = "Access Fitness", StartDate = DateTime.Parse("10-05-2016"), StartTime = "7pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "CoreTraining").CategoryID, ClassName = "CoreTraining", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Aronda").InstructorID, DublinArea = "DunLaoghaire", GymName = "Warriors Gym", StartDate = DateTime.Parse("11-05-2016"), StartTime = "5pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "CrossFit").CategoryID, ClassName = "CrossFit", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Michael").InstructorID, DublinArea = "Tallaght", GymName = "Westpark Fitness", StartDate = DateTime.Parse("12-05-2016"), StartTime = "9am", MaxEnroll = 15, Status = Status.Fullybooked, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "CrossFit").CategoryID, ClassName = "CrossFit", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Billy").InstructorID, DublinArea = "Dundrum", GymName = "Rock Fitness", StartDate = DateTime.Parse("09-05-2016"), StartTime = "5pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "HIIT").CategoryID, ClassName = "HIIT", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Geral").InstructorID, DublinArea = "Tallaght", GymName = "Westpark Fitness", StartDate = DateTime.Parse("10-05-2016"), StartTime = "6pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "HIIT").CategoryID, ClassName = "HIIT", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Ciaron").InstructorID, DublinArea = "Rathmines", GymName = "Swan Leisure", StartDate = DateTime.Parse("11-05-2016"), StartTime = "5pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Kettlebells").CategoryID, ClassName = "Kettlebells", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Chris").InstructorID, DublinArea = "Dundrum", GymName = "Rock Fitness", StartDate = DateTime.Parse("12-05-2016"), StartTime = "10am", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Kettlebells").CategoryID, ClassName = "Kettlebells", Description = "", InstructorID = instructors.Single(i => i.FirstName== "Eric").InstructorID, DublinArea = "TempleBar", GymName = "Crunch Fitness Temple Bar", StartDate = DateTime.Parse("13-05-2016"), StartTime = "9am", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Kickboxing").CategoryID, ClassName = "Kickboxing", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Michael").InstructorID, DublinArea = "DublinCityCentre", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("09-05-2016"), StartTime = "5pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Swimming").CategoryID, ClassName = "Swimming", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Paul").InstructorID, DublinArea = "Tallaght", GymName = "Westpark Fitness", StartDate = DateTime.Parse("13-05-2016"), StartTime = "6pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Yoga").CategoryID, ClassName = "Yoga", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Declan").InstructorID, DublinArea = "DublinCityCentre", GymName = "Markievicz Leisure Centre", StartDate = DateTime.Parse("10-05-2016"), StartTime = "7pm", MaxEnroll = 15, Status = Status.Fullybooked, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Yoga").CategoryID, ClassName = "Yoga", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Aronda").InstructorID, DublinArea = "Tallaght", GymName = "Westpark Fitness", StartDate = DateTime.Parse("09-05-2016"), StartTime = "7pm", MaxEnroll = 15, Status = Status.Available, Records = new List <RegistrationRecord>(){} },
//                new Schedule {CategoryID = categories.Single(c => c.Name == "Zumba").CategoryID,  ClassName = "Zumba", Description = "", InstructorID = instructors.Single(i => i.FirstName == "Frank").InstructorID, DublinArea = "Tallaght", GymName = "Westpark Fitness", StartDate = DateTime.Parse("13-05-2016"), StartTime = "7pm", MaxEnroll = 15, Status = Status.Fullybooked, Records = new List <RegistrationRecord>(){} },
//            };
//            schedules.ForEach(s => context.Schedules.Add(s));
//            context.SaveChanges();

//            var records = new List<RegistrationRecord>
//            {
//            new RegistrationRecord { ScheduleID = schedules.Single(s => s.ClassName == "Abs").ScheduleID, ParticipantID = participants.Single(p => p.FirstName == "Aronda").ParticipantID, RegistraionDate = DateTime.Parse("01-05-2016"), Status = RegistrationStatus.Reserve },
//            new RegistrationRecord { ScheduleID = schedules.Single(s => s.ClassName == "AquaAerobics").ScheduleID, ParticipantID = participants.Single(p => p.FirstName == "Adrian").ParticipantID, RegistraionDate = DateTime.Parse("03-05-2016"), Status = RegistrationStatus.Cancel },
//            new RegistrationRecord { ScheduleID = schedules.Single(s => s.ClassName == "BodySculpt").ScheduleID, ParticipantID = participants.Single(p => p.FirstName == "Michael").ParticipantID, RegistraionDate = DateTime.Parse("05-05-2016"), Status = RegistrationStatus.WaitingList },
//            new RegistrationRecord { ScheduleID = schedules.Single(s => s.ClassName == "CrossFit").ScheduleID, ParticipantID = participants.Single(p => p.FirstName == "Billy").ParticipantID, RegistraionDate = DateTime.Parse("01-05-2016"), Status = RegistrationStatus.Reserve },
//            new RegistrationRecord { ScheduleID = schedules.Single(s => s.ClassName == "Yoga").ScheduleID, ParticipantID = participants.Single(p => p.FirstName == "Aronda").ParticipantID, RegistraionDate = DateTime.Parse("03-05-2016"), Status = RegistrationStatus.Cancel },
//            };

//            foreach (RegistrationRecord e in records)
//            {
//                var recordtInDataBase = context.Records.Where(
//                    s =>
//                         s.ParticipantID == e.ParticipantID &&
//                         s.ScheduleID == e.ScheduleID).SingleOrDefault();
//                if (recordtInDataBase == null)
//                {
//                    context.Records.Add(e);
//                }
//            }
//            context.SaveChanges();
//        }
//    }    
//}