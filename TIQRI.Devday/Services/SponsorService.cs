using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Services
{
    public class SponsorService
    {
        public bool CreateSponsor(Sponsor sponsor, HttpPostedFileBase logoFile, AppContext db,HttpPostedFileBase BannerFile)
        {
            if (logoFile != null)
            { 
                Image logo = new Image { ImageContent = ConvertToBytes(logoFile), DateCreated = DateTime.Now, DateLastUpdated = DateTime.Now };
                sponsor.Logo = db.Images.Add(logo);
                
            }

            if (BannerFile != null)
            {
                Image banner = new Image { ImageContent = ConvertToBytes(BannerFile), DateCreated = DateTime.Now, DateLastUpdated = DateTime.Now };
                sponsor.Banner = db.Images.Add(banner);

            }

            sponsor.Archived = false;
            sponsor.DateCreated = DateTime.Now;
            sponsor.DateLastUpdated = DateTime.Now;
            
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