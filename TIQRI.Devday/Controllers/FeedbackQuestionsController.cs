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
    public class FeedbackQuestionsController : Controller
    {
        private AppContext db = new AppContext();

        // GET: FeedbackQuestions
        public async Task<ActionResult> Index()
        {
            return View(await db.FeedbackQuestions.ToListAsync());
        }

        // GET: FeedbackQuestions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackQuestion feedbackQuestion = await db.FeedbackQuestions.FindAsync(id);
            if (feedbackQuestion == null)
            {
                return HttpNotFound();
            }
            return View(feedbackQuestion);
        }

        // GET: FeedbackQuestions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Question,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] FeedbackQuestion feedbackQuestion)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackQuestions.Add(feedbackQuestion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(feedbackQuestion);
        }

        // GET: FeedbackQuestions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackQuestion feedbackQuestion = await db.FeedbackQuestions.FindAsync(id);
            if (feedbackQuestion == null)
            {
                return HttpNotFound();
            }
            return View(feedbackQuestion);
        }

        // POST: FeedbackQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Question,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] FeedbackQuestion feedbackQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackQuestion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(feedbackQuestion);
        }

        // GET: FeedbackQuestions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackQuestion feedbackQuestion = await db.FeedbackQuestions.FindAsync(id);
            if (feedbackQuestion == null)
            {
                return HttpNotFound();
            }
            return View(feedbackQuestion);
        }

        // POST: FeedbackQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FeedbackQuestion feedbackQuestion = await db.FeedbackQuestions.FindAsync(id);
            db.FeedbackQuestions.Remove(feedbackQuestion);
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
