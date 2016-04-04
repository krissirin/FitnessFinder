using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessStore.Models
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DefaultConnection")
        {
            Database.SetInitializer<FitnessContext>(new DropCreateDatabaseIfModelChanges<FitnessContext>());
        }
        public DbSet<ClassType> ClassTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<RegistrationRecord> RegistrationRecords { get; set; }
    }
}