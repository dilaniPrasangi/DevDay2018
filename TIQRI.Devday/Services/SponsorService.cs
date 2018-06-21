using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models;

namespace TIQRI.Devday.Services
{
    public class SponsorService
    {
        public bool CreateSponsor(Sponsor sponsor, HttpPostedFileBase logoFile, AppContext db)
        {
            Image logo = new Image { ImageContent = ConvertToBytes(logoFile),DateCreated = DateTime.Now,DateLastUpdated=DateTime.Now };
            Image savedLogo = db.Images.Add(logo);
            
            sponsor.Archived = false;
            sponsor.DateCreated = DateTime.Now;
            sponsor.DateLastUpdated = DateTime.Now;
            sponsor.Logo = savedLogo;
            //@event.UserCreated = HttpContext.cu
            db.Sponsors.Add(sponsor);
            db.SaveChanges();
            return true;

        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)

        {

            byte[] imageBytes = null;

            BinaryReader reader = new BinaryReader(image.InputStream);

            imageBytes = reader.ReadBytes((int)image.ContentLength);

            return imageBytes;

        }
    }
}