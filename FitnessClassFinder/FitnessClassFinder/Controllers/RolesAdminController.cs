using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessClassFinder.Models;

namespace FitnessClassFinder.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
        private FitnessDBContext db = new FitnessDBContext();

        //Adding Admin role
        //public RolesAdminController()
        //{
        //}

        //public RolesAdminController(ApplicationUserManager userManager,
        //    ApplicationRoleManager roleManager)
        //{
        //    UserManager = userManager;
        //    RoleManager = roleManager;
        //}

        //private ApplicationUserManager _userManager;
        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    set
        //    {
        //        _userManager = value;
        //    }
        //}

        //private ApplicationRoleManager _roleManager;
        //public ApplicationRoleManager RoleManager
        //{
        //    get
        //    {
        //        return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
        //    }
        //    private set
        //    {
        //        _roleManager = value;
        //    }
        //}




        // GET: /Roles/
        public async Task<ActionResult> Index()
        {
            return View(await db.RoleViewModels.ToListAsync());
        }

        // GET: RoleViewModels/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleViewModel = await db.RoleViewModels.FindAsync(id);
            if (roleViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // GET: RoleViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RoleViewModels.Add(roleViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(roleViewModel);
        }

        // GET: RoleViewModels/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleViewModel = await db.RoleViewModels.FindAsync(id);
            if (roleViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // POST: RoleViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(roleViewModel);
        }

        // GET: RoleViewModels/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleViewModel = await db.RoleViewModels.FindAsync(id);
            if (roleViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // POST: RoleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            RoleViewModel roleViewModel = await db.RoleViewModels.FindAsync(id);
            db.RoleViewModels.Remove(roleViewModel);
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
