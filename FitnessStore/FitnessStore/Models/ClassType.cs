using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FitnessStore.Models
{
    public enum SelectClass
    {
        Abs, [Display(Name = "Aqua Aerobics")]
        AquaAerobics, [Display(Name = "Body Sculpt")]
        BodySculpt, Bootcamp, Boxing, Circuits,
        [Display(Name = "Core Training")]
        CoreTraining, [Display(Name = "Cross-Fit")]
        CrossFit, HIIT, Kettlebells, Kickboxing,
        [Display(Name = "Personal Training")]
        PersonalTraining, Pilates, Spinning, Step, Swimming, TRX,
        [Display(Name = "Weight Training")]
        WeightTraining, Yoga, Zumba
    }

    public class ClassType
    {
        //PK 
        [Key]
        public int ClassTypeID { get; set; }

        //Class type
        [Display(Name = "Class Type")]
        [Required(ErrorMessage = "Please select class type")]
        public SelectClass SelectClass { get; set; }

        //Description
        [StringLength(10000), Display(Name = "Class Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<Schedule> Schedules { get; set; }

    }
}