using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitnessClassFinder1.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FitnessClassFinder1.DAL
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("FitnessContext")
        {
            Database.SetInitializer<FitnessContext>(new DropCreateDatabaseIfModelChanges<FitnessContext>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<RegistrationRecord> Records { get; set; }
        public DbSet<BookingCart> BookingCarts { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }

        //the OnModelCreating method prevents table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        //public System.Data.Entity.DbSet<FitnessClassFinder1.Models.RoleViewModel> RoleViewModels { get; set; }

        //public System.Data.Entity.DbSet<FitnessClassFinder1.Models.EditUserViewModel> EditUserViewModels { get; set; }
    }
}