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
    public class EditUsersController : Controller
    {
        private FitnessDBContext db = new FitnessDBContext();

        // GET: EditUsers
        public async Task<ActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        // GET: EditUsers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditUserViewModel editUserViewModel = await db.Users.FindAsync(id);
            if (editUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editUserViewModel);
        }

        // GET: EditUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,FullName,PhoneNumber,Address")] EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(editUserViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(editUserViewModel);
        }

        // GET: EditUsers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditUserViewModel editUserViewModel = await db.Users.FindAsync(id);
            if (editUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editUserViewModel);
        }

        // POST: EditUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,FullName,PhoneNumber,Address")] EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editUserViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(editUserViewModel);
        }

        // GET: EditUsers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditUserViewModel editUserViewModel = await db.Users.FindAsync(id);
            if (editUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editUserViewModel);
        }

        // POST: EditUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            EditUserViewModel editUserViewModel = await db.Users.FindAsync(id);
            db.Users.Remove(editUserViewModel);
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
