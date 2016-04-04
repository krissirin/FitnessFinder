using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessStore.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Address is too long")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        public int? RecordID { get; set; }
        public virtual RegistrationRecord Records { get; set; }
    }
}