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
using TIQRI.Devday.Services;

namespace TIQRI.Devday.Controllers
{
    public class FeedbackTypesController : Controller
    {
        private static AppContext db = new AppContext();
        private FeedbackTypeService feedbackTypeService = new FeedbackTypeService(db);


        // GET: FeedbackTypes
        public async Task<ActionResult> Index()
        {
            return View(await feedbackTypeService.GetAll());
        }

        // GET: FeedbackTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackType feedbackType = await feedbackTypeService.GetFeedbackTypeByIdAsync(id);
            if (feedbackType == null)
            {
                return HttpNotFound();
            }
            return View(feedbackType);
        }

        // GET: FeedbackTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FeedbackTypeName,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] FeedbackType feedbackType)
        {
            if (ModelState.IsValid)
            {
                feedbackTypeService.Post(feedbackType);
                return RedirectToAction("Index");
            }

            return View(feedbackType);
        }

        // GET: FeedbackTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackType feedbackType = await feedbackTypeService.GetFeedbackTypeByIdAsync(id);
            if (feedbackType == null)
            {
                return HttpNotFound();
            }
            return View(feedbackType);
        }

        // POST: FeedbackTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FeedbackTypeName,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] FeedbackType feedbackType)
        {
            if (ModelState.IsValid)
            {
                feedbackTypeService.Edit(feedbackType);
                return RedirectToAction("Index");
            }
            return View(feedbackType);
        }

        // GET: FeedbackTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackType feedbackType = await feedbackTypeService.GetFeedbackTypeByIdAsync(id);
            if (feedbackType == null)
            {
                return HttpNotFound();
            }
            return View(feedbackType);
        }

        // POST: FeedbackTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FeedbackType feedbackType = await feedbackTypeService.GetFeedbackTypeByIdAsync(id);
            feedbackTypeService.Delete(feedbackType);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                feedbackTypeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
