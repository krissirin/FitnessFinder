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
    public class ParticipantsController : Controller
    {
        private FitnessDBContext db = new FitnessDBContext();

        // GET: Participants
        public async Task<ActionResult> Index()
        {
            var participants = db.Participants.Include(p => p.Records);
            return View(await participants.ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = await db.Participants.FindAsync(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            ViewBag.RecordID = new SelectList(db.Records, "RecordID", "Status");
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ParticipantID,FirstName,LastName,Address,Email,EnrollmentDate,Status,RecordID")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Participants.Add(participant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RecordID = new SelectList(db.Records, "RecordID", "Status", participant.RecordID);
            return View(participant);
        }

        // GET: Participants/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = await db.Participants.FindAsync(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecordID = new SelectList(db.Records, "RecordID", "Status", participant.RecordID);
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ParticipantID,FirstName,LastName,Address,Email,EnrollmentDate,Status,RecordID")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RecordID = new SelectList(db.Records, "RecordID", "Status", participant.RecordID);
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = await db.Participants.FindAsync(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Participant participant = await db.Participants.FindAsync(id);
            db.Participants.Remove(participant);
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
