using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;
using TIQRI.Devday.Services;

namespace TIQRI.Devday.Controllers
{
    public class UserStatusController : Controller
    {
        #region Properties

        //App Context
        private AppContext db = new AppContext();

        //User Type Service
        private UserStatusService service = new UserStatusService();

        #endregion

        #region Public Methods

        // GET: UserStatus
        public ActionResult Index()
        {
            return View(db.UserStatuses.ToList());
        }

        // GET: UserStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatus userStatus = db.UserStatuses.Find(id);
            if (userStatus == null)
            {
                return HttpNotFound();
            }
            return View(userStatus);
        }

        // GET: UserStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserStatusId,UserStatusName,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] UserStatus userStatus)
        {
            if (ModelState.IsValid)
            {
                service.CreateUserStatus(userStatus, db);
                return RedirectToAction("Index");
            }

            return View(userStatus);
        }

        // GET: UserStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatus userStatus = db.UserStatuses.Find(id);
            if (userStatus == null)
            {
                return HttpNotFound();
            }
            return View(userStatus);
        }

        // POST: UserStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserStatusId,UserStatusName,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] UserStatus userStatus)
        {
            if (ModelState.IsValid)
            {
                service.EditUserStatus(userStatus, db);
                return RedirectToAction("Index");
            }
            return View(userStatus);
        }

        // GET: UserStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStatus userStatus = db.UserStatuses.Find(id);
            if (userStatus == null)
            {
                return HttpNotFound();
            }
            return View(userStatus);
        }

        // POST: UserStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            service.DeleteUserStatus(id, db);
            return RedirectToAction("Index");
        }

        #endregion

        #region Protected Method

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
