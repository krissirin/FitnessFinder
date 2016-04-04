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
    public class UserAdminController : Controller
    {
        private FitnessDBContext db = new FitnessDBContext();

        // GET: UserAdmin
        public async Task<ActionResult> Index()
        {
            return View(await db.EditUserViewModels.ToListAsync());
        }

        // GET: UserAdmin/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditUserViewModel editUserViewModel = await db.EditUserViewModels.FindAsync(id);
            if (editUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editUserViewModel);
        }

    //    GET: UserAdmin/Create
    //   [HttpPost]
    //    public ActionResult Create(RegisterViewModel userViewModel, params string[] selectedRoles)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new ApplicationUser
    //            {
    //                UserName = userViewModel.Email,
    //                Email =
    //                userViewModel.Email,
    //                Add other Info:
    //                BirthDate = userViewModel.BirthDate,
    //                Address = userViewModel.Address,
    //                Town = userViewModel.Town,
    //                County = userViewModel.County,
    //                Postcode = userViewModel.Postcode
    //            };

    //        Add the Address Info:
    //            user.BirthDate = userViewModel.BirthDate;
    //        user.Address = userViewModel.Address;
    //        user.Town = userViewModel.Town;
    //        user.County = userViewModel.County;
    //        user.Postcode = userViewModel.Postcode;

    //        Then create:
    //            var adminresult = await UserManager.CreateAsync(user, userViewModel.Password);

    //        Add User to the selected Roles
    //            if (adminresult.Succeeded)
    //        {
    //            if (selectedRoles != null)
    //            {
    //                var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles);
    //                if (!result.Succeeded)
    //                {
    //                    ModelState.AddModelError("", result.Errors.First());
    //                    ViewBag.RoleId = new SelectList(await RoleManager.Roles.ToListAsync(), "Name", "Name");
    //                    return View();
    //                }
    //            }
    //        }
    //        else
    //        {
    //            ModelState.AddModelError("", adminresult.Errors.First());
    //            ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
    //            return View();
    //        }
    //        return RedirectToAction("Index");
    //    }
    //    ViewBag.RoleId = new SelectList(RoleManager.Roles, "Name", "Name");
    //        return View();
    //}

    // POST: UserAdmin/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,Name,BirthDate,Address,Town,County,Postcode")] EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                db.EditUserViewModels.Add(editUserViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(editUserViewModel);
        }

        // GET: UserAdmin/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditUserViewModel editUserViewModel = await db.EditUserViewModels.FindAsync(id);
            if (editUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editUserViewModel);
        }

        // POST: UserAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,Name,BirthDate,Address,Town,County,Postcode")] EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editUserViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(editUserViewModel);
        }

        // GET: UserAdmin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EditUserViewModel editUserViewModel = await db.EditUserViewModels.FindAsync(id);
            if (editUserViewModel == null)
            {
                return HttpNotFound();
            }
            return View(editUserViewModel);
        }

        // POST: UserAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            EditUserViewModel editUserViewModel = await db.EditUserViewModels.FindAsync(id);
            db.EditUserViewModels.Remove(editUserViewModel);
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
