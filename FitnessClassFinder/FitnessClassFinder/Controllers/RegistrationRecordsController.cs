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

namespace FitnessClassFinder.Controllers
{
    public class RegistrationRecordsController : Controller
    {
        private FitnessDBContext db = new FitnessDBContext();

        // GET: RegistrationRecords
        public async Task<ActionResult> Index()
        {
            return View(await db.Records.ToListAsync());
        }

        // GET: RegistrationRecords/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationRecord registrationRecord = await db.Records.FindAsync(id);
            if (registrationRecord == null)
            {
                return HttpNotFound();
            }
            return View(registrationRecord);
        }

        // GET: RegistrationRecords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RecordID,FitnessClassID,ParticipantID,RegistraionDate,Status")] RegistrationRecord registrationRecord)
        {
            if (ModelState.IsValid)
            {
                db.Records.Add(registrationRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(registrationRecord);
        }

        // GET: RegistrationRecords/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationRecord registrationRecord = await db.Records.FindAsync(id);
            if (registrationRecord == null)
            {
                return HttpNotFound();
            }
            return View(registrationRecord);
        }

        // POST: RegistrationRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RecordID,FitnessClassID,ParticipantID,RegistraionDate,Status")] RegistrationRecord registrationRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(registrationRecord);
        }

        // GET: RegistrationRecords/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationRecord registrationRecord = await db.Records.FindAsync(id);
            if (registrationRecord == null)
            {
                return HttpNotFound();
            }
            return View(registrationRecord);
        }

        // POST: RegistrationRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RegistrationRecord registrationRecord = await db.Records.FindAsync(id);
            db.Records.Remove(registrationRecord);
            await db.SaveChangesAsync();
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
