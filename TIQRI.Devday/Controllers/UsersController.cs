#region Using Statements

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models;
using TIQRI.Devday.Services;

#endregion

namespace TIQRI.Devday.Controllers
{
    public class UsersController : Controller
    {
        #region Properties

        private AppContext db = new AppContext();

        private UserService service = new UserService();

        #endregion

        #region Public Methods

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.TShirtSize).Include(u => u.UserStatus).Include(u => u.UserType);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.TShirtSizeId = new SelectList(db.TShirtSizes, "Id", "Size");
            ViewBag.UserStatusId = new SelectList(db.UserStatuses, "Id", "UserStatusName");
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,UserEmail,SecurityCode,FirstName,LastName,Company,Gender,ContactNumber,UserDescription,UserStatusId,UserTypeId,TShirtSizeId,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] User user)
        {
            if (ModelState.IsValid)
            {
                service.CreateUser(user, db);
                return RedirectToAction("Index");
            }

            ViewBag.TShirtSizeId = new SelectList(db.TShirtSizes, "Id", "Size", user.TShirtSizeId);
            ViewBag.UserStatusId = new SelectList(db.UserStatuses, "Id", "UserStatusName", user.UserStatusId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.TShirtSizeId = new SelectList(db.TShirtSizes, "Id", "Size", user.TShirtSizeId);
            ViewBag.UserStatusId = new SelectList(db.UserStatuses, "Id", "UserStatusName", user.UserStatusId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName", user.UserTypeId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,UserEmail,SecurityCode,FirstName,LastName,Company,Gender,ContactNumber,UserDescription,UserStatusId,UserTypeId,TShirtSizeId,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] User user)
        {
            if (ModelState.IsValid)
            {
                service.EditUser(user, db);
                return RedirectToAction("Index");
            }
            ViewBag.TShirtSizeId = new SelectList(db.TShirtSizes, "Id", "Size", user.TShirtSizeId);
            ViewBag.UserStatusId = new SelectList(db.UserStatuses, "Id", "UserStatusName", user.UserStatusId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "Id", "UserTypeName", user.UserTypeId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {         
            service.DeleteUser(id, db);
            return RedirectToAction("Index");
        }

        #endregion

        #region Protected Methods

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}
