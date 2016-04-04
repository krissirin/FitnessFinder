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


        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}