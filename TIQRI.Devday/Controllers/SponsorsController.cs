
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
    public class SponsorsController : Controller
    {
        private AppContext db = new AppContext();
        private SponsorService service = new SponsorService();
        private EventService eventService = new EventService();
        // GET: Sponsors
        public ActionResult Index()
        {
            return View(db.Sponsors.ToList());
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // GET: Sponsors/Create
        public ActionResult Create()
        {
            
            ViewBag.EventId = new SelectList(eventService.GetActiveEvents(db), "Id", "Name");
            return View();
        }

        // POST: Sponsors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Description,ContactNumber,Email,EventId")] Sponsor sponsor, HttpPostedFileBase LogoImageData,HttpPostedFileBase BannerImageData)
        {
            
            if (ModelState.IsValid)
            {
                service.CreateSponsor(sponsor, LogoImageData, db, BannerImageData);
                return RedirectToAction("Index");
            }

            return View(sponsor);
        }

        // GET: Sponsors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Description,ContactNumber,Email,Archived,DateLastUpdated,UserLastUpdated,DateCreated,UserCreated")] Sponsor sponsor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsor);
        }

        // GET: Sponsors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = db.Sponsors.Find(id);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // POST: Sponsors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsor sponsor = db.Sponsors.Find(id);
            db.Sponsors.Remove(sponsor);
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
