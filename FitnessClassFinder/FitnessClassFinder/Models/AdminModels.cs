using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FitnessClassFinder.Models
{
    public class RoleViewModel
    {
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }
    }

    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        //Add Profile Data properties:

        [StringLength(50, ErrorMessage = "Name is too long")]
        public string FullName { get; set; }

        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Please enter your location e.g.Dublin")]
        public string Address { get; set; }

        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}