using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;
using TIQRI.Devday.Services;

namespace TIQRI.Devday.Controllers
{
    public class FeedbacksController : Controller
    {
        private static AppContext db = new AppContext();
        private FeedbackService feedbackService = new FeedbackService(db); 

        // GET: Feedbacks
        public async Task<ActionResult> Index()
        {
            var feedbacks = feedbackService.GetAll();
            return View(await feedbacks.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback feedback = await feedbackService.GetFeedbackByIdAsync(id);
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
                feedbackService.Post(feedback);
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
            Feedback feedback = await feedbackService.GetFeedbackByIdAsync(id);
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
                feedbackService.Edit(feedback);
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
            Feedback feedback = await feedbackService.GetFeedbackByIdAsync(id);
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
            Feedback feedback = await feedbackService.GetFeedbackByIdAsync(id);
            feedbackService.Delete(feedback);            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                feedbackService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
