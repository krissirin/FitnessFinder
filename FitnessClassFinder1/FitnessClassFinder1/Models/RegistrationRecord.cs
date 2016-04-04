using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessClassFinder1.Models
{
    public enum RegistrationStatus { Reserve, Cancel, [Display(Name = "Waiting List")] WaitingList }

    public class RegistrationRecord
    {
        [Key]
        public int RecordID { get; set; }

        public int ScheduleID { get; set; }

        public int ParticipantID { get; set; }

        [Display(Name = "Record Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistraionDate { get; set; }

        public RegistrationStatus Status { get; set; }

        public virtual Schedule Schedule { get; set; }
        public virtual Participant Participant { get; set; }

    }
}