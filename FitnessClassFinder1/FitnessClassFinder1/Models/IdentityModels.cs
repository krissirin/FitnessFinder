using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        //Add Profile Data properties:

        [StringLength(20, ErrorMessage = "Name is too long")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [StringLength(20, ErrorMessage = "Address is too long")]
        public string Address { get; set; }
        public string Town { get; set; }
        public string County { get; set; }

        [Required(ErrorMessage = "Please enter a valid postcode e.g. D24")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "Postcode range from 2 to 10 characters")]
        public string Postcode { get; set; }


        // Concatenate the user profie info for display in tables and such:
        public string DisplayProfile
        {
            get
            {
                string dpName = string.IsNullOrWhiteSpace(this.Name) ? "" : this.Name;
                string dpAddress = string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
                string dpTown = string.IsNullOrWhiteSpace(this.Town) ? "" : this.Town;
                string dpCounty = string.IsNullOrWhiteSpace(this.County) ? "" : this.County;
                string dpPostcode = string.IsNullOrWhiteSpace(this.Postcode) ? "" : this.Postcode;
                return string.Format("{0} {1} {2} {3} {4}", dpName, dpAddress, dpTown, dpCounty, dpPostcode);
            }
        }
    }


    // Add Identity roles for users e.g. admin, participant and instructor to be added
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
