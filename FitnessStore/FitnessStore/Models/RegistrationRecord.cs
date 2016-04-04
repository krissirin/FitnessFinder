using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessStore.Models
{
    public class RegistrationRecord
    {
        [Key]
        public int RecordID { get; set; }

        public int ScheduleID { get; set; }

        public int ParticipantID { get; set; }

        [Display(Name = "Record Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistraionDate { get; set; }

        public string Status { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}