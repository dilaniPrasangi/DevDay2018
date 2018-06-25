using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIQRI.Devday.Context;

namespace TIQRI.Devday.Controllers
{
    public class ImageController : Controller
    {
        private AppContext db = new AppContext();
        // GET: Image
        public ActionResult Index(int id)
        {
            var imageToRetrive = db.Images.Find(id);
            return File(imageToRetrive.ImageContent, imageToRetrive.ContentType);
        }
    }
}