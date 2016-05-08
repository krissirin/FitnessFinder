using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessClassFinder.Models;
using FitnessClassFinder.Extensions;

namespace FitnessClassFinder.Controllers
{
    public class ClassSchedulesController : Controller
    {
        private FitnessDBContext db = new FitnessDBContext();

        // GET: ClassSchedules
        public async Task<ActionResult> Index(string searchArea, string searchClass, string sortOrder)
        {
            //Add Sorting Functionality
            ViewBag.AreaSortParm = String.IsNullOrEmpty(sortOrder) ? "Area" : "";
            ViewBag.ClassSortParm = String.IsNullOrEmpty(sortOrder) ? "Class" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            //Sort by Area
            var AreaLst = new List<string>();
            var AreaQry = from a in db.Schedules
                           orderby a.LocalArea
                           select a.LocalArea;

            AreaLst.AddRange(AreaQry.Distinct());
            ViewBag.searchArea = new SelectList(AreaLst);

            //Sort by Class name
            var ClassLst = new List<string>();
            var ClassQry = from s in db.Schedules
                           orderby s.ClassName
                           select s.ClassName;

            ClassLst.AddRange(ClassQry.Distinct());
            ViewBag.searchClass = new SelectList(ClassLst);


            var schedules = from s in db.Schedules
                         select s;
            //{
            //    schedules = schedules.Where(s => s.LocalArea.ToUpper().Contains(Search_Data.ToUpper())
            //        || s.ClassName.ToUpper().Contains(Search_Data.ToUpper()));
            //}
            switch (sortOrder)
            {
                case "Area":
                    schedules = schedules.OrderByDescending(s => s.LocalArea);
                    break;
                case "Class":
                    schedules = schedules.OrderByDescending(s => s.ClassName);
                    break;
                case "Date":
                    schedules = schedules.OrderBy(s => s.StartDate);
                    break;
                case "Date_desc":
                    schedules = schedules.OrderByDescending(s => s.StartDate);
                    break;

                default:
                    schedules = schedules.OrderBy(s => s.LocalArea);
                    break;
            }

            if (!String.IsNullOrEmpty(searchClass))
            {
                schedules = schedules.Where(s => s.ClassName.Contains(searchClass));
            }
            if (!String.IsNullOrEmpty(searchArea))
            {
                schedules = schedules.Where(x => x.LocalArea == searchArea);
            }

            return View(await schedules.ToListAsync());
        }

        // GET: ClassSchedules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSchedule classSchedule = await db.Schedules.FindAsync(id);
            if (classSchedule == null)
            {
                return HttpNotFound();
            }
            return View(classSchedule);
        }

        // GET: ClassSchedules/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryDescription");
            return View();
        }

        // POST: ClassSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FitnessClassID,SelectArea,LocalArea,ClassName,Description,BusinessName,StartDate,StartTime,Duration,Status,MaxEnroll,CategoryID")] ClassSchedule classSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(classSchedule);
                await db.SaveChangesAsync();
                this.AddNotification("Class created.", NotificationType.INFO);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryDescription", classSchedule.CategoryID);
            return View(classSchedule);
        }

        // GET: ClassSchedules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSchedule classSchedule = await db.Schedules.FindAsync(id);
            if (classSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryDescription", classSchedule.CategoryID);
            return View(classSchedule);
        }

        // POST: ClassSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FitnessClassID,SelectArea,LocalArea,ClassName,Description,BusinessName,StartDate,StartTime,Duration,Status,MaxEnroll,CategoryID")] ClassSchedule classSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classSchedule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                this.AddNotification("Class edited.", NotificationType.INFO);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryDescription", classSchedule.CategoryID);
            return View(classSchedule);
        }

        // GET: ClassSchedules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassSchedule classSchedule = await db.Schedules.FindAsync(id);
            if (classSchedule == null)
            {
                return HttpNotFound();
            }
            return View(classSchedule);
        }

        // POST: ClassSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClassSchedule classSchedule = await db.Schedules.FindAsync(id);
            db.Schedules.Remove(classSchedule);
            await db.SaveChangesAsync();
            this.AddNotification("Class deleted.", NotificationType.INFO);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
