using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Controllers
{
    public class FeedbacksController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Feedbacks
        public async Task<ActionResult> Index()
        {
            var feedbacks = db.Feedbacks.Include(f => f.FeedbackQuestion).Include(f => f.FeedbackType).Include(f => f.User);
            return View(await feedbacks.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = await db.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.FeedbackQuestionId = new SelectList(db.FeedbackQuestions, "Id", "Question");
            ViewBag.FeedbackTypeId = new SelectList(db.FeedbackTypes, "Id", "FeedbackTypeName");
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserEmail");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FeedbackScore,CategoryId,Comment,UserId,FeedbackTypeId,FeedbackQuestionId,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Feedbacks.Add(feedback);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FeedbackQuestionId = new SelectList(db.FeedbackQuestions, "Id", "Question", feedback.FeedbackQuestionId);
            ViewBag.FeedbackTypeId = new SelectList(db.FeedbackTypes, "Id", "FeedbackTypeName", feedback.FeedbackTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserEmail", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = await db.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeedbackQuestionId = new SelectList(db.FeedbackQuestions, "Id", "Question", feedback.FeedbackQuestionId);
            ViewBag.FeedbackTypeId = new SelectList(db.FeedbackTypes, "Id", "FeedbackTypeName", feedback.FeedbackTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserEmail", feedback.UserId);
            return View(feedback);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FeedbackScore,CategoryId,Comment,UserId,FeedbackTypeId,FeedbackQuestionId,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FeedbackQuestionId = new SelectList(db.FeedbackQuestions, "Id", "Question", feedback.FeedbackQuestionId);
            ViewBag.FeedbackTypeId = new SelectList(db.FeedbackTypes, "Id", "FeedbackTypeName", feedback.FeedbackTypeId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "UserEmail", feedback.UserId);
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = await db.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Feedback feedback = await db.Feedbacks.FindAsync(id);
            db.Feedbacks.Remove(feedback);
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
