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

namespace TIQRI.Devday.Controllers
{
    public class TShirtSizesController : Controller
    {
        private AppContext db = new AppContext();

        // GET: TShirtSizes
        public ActionResult Index()
        {
            return View(db.TShirtSizes.ToList());
        }

        // GET: TShirtSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TShirtSize tShirtSize = db.TShirtSizes.Find(id);
            if (tShirtSize == null)
            {
                return HttpNotFound();
            }
            return View(tShirtSize);
        }

        // GET: TShirtSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TShirtSizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TShirtSizeId,Size,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] TShirtSize tShirtSize)
        {
            if (ModelState.IsValid)
            {
                db.TShirtSizes.Add(tShirtSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tShirtSize);
        }

        // GET: TShirtSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TShirtSize tShirtSize = db.TShirtSizes.Find(id);
            if (tShirtSize == null)
            {
                return HttpNotFound();
            }
            return View(tShirtSize);
        }

        // POST: TShirtSizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TShirtSizeId,Size,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] TShirtSize tShirtSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tShirtSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tShirtSize);
        }

        // GET: TShirtSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TShirtSize tShirtSize = db.TShirtSizes.Find(id);
            if (tShirtSize == null)
            {
                return HttpNotFound();
            }
            return View(tShirtSize);
        }

        // POST: TShirtSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TShirtSize tShirtSize = db.TShirtSizes.Find(id);
            db.TShirtSizes.Remove(tShirtSize);
            db.SaveChanges();
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
