
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        public ActionResult Index(int?id)
        {
            
                return View(service.GetSponsors(db, false,id));
           
                
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sponsor sponsor = service.GetSponsor((int)id,db);
            if (sponsor == null)
            {
                return HttpNotFound();
            }
            return View(sponsor);
        }

        // GET: Sponsors/Create
        public ActionResult Create(int?id)
        {
            
            ViewBag.EventId = new SelectList(eventService.GetActiveEvents(db), "Id", "Name",id);
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
            ViewBag.EventId = new SelectList(eventService.GetActiveEvents(db), "Id", "Name");
            Sponsor sponsor = service.GetSponsor((int)id, db);
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
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Description,ContactNumber,Email,Archived,EventId")] Sponsor sponsor, HttpPostedFileBase LogoImageData, HttpPostedFileBase BannerImageData)
        {
            if (ModelState.IsValid)
            {
                service.EditSponsor(sponsor, LogoImageData, db, BannerImageData);
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
            Sponsor sponsor = service.GetSponsor((int)id, db);
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
            service.DeleteSponsor(id, db);
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
