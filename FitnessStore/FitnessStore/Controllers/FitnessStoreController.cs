using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FitnessStore.Models;

namespace FitnessStore.Controllers
{
    public class FitnessStoreController : Controller
    {
        // GET: FitnessStore
        public ActionResult Index()
        {
            var classtypes = new List<ClassType>
    {
        new ClassType { SelectClass = SelectClass.Abs},
        new ClassType { SelectClass = SelectClass.AquaAerobics},
        new ClassType { SelectClass = SelectClass.BodySculpt},
        new ClassType { SelectClass = SelectClass.Bootcamp},
        new ClassType { SelectClass = SelectClass.Boxing},
        new ClassType { SelectClass = SelectClass.Circuits},
        new ClassType { SelectClass = SelectClass.CoreTraining},
        new ClassType { SelectClass = SelectClass.CrossFit},
        new ClassType { SelectClass = SelectClass.HIIT},
        new ClassType { SelectClass = SelectClass.Kettlebells},
        new ClassType { SelectClass = SelectClass.Kickboxing},
        new ClassType { SelectClass = SelectClass.PersonalTraining},
        new ClassType { SelectClass = SelectClass.Pilates},
        new ClassType { SelectClass = SelectClass.Spinning},
        new ClassType { SelectClass = SelectClass.Step},
        new ClassType { SelectClass = SelectClass.Swimming},
        new ClassType { SelectClass = SelectClass.TRX},
        new ClassType { SelectClass = SelectClass.WeightTraining},
        new ClassType { SelectClass = SelectClass.Yoga},
        new ClassType { SelectClass = SelectClass.Zumba}

    };
            return View(classtypes);


        }
        //GET: /FitnessStore/Browse
        public ActionResult Browse(SelectClass selectclass)
        {
            var classModel = new ClassType { SelectClass = selectclass };
            return View(classModel);
        }

        //GET: /FitnessStore/Details
        public ActionResult Details(int id)
        {
            var schdule = new Schedule { ClassName = "Abs" + id };
            return View(schdule);

        }
    }
}