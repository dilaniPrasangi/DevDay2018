using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (logoFile != null && logoFile.ContentLength >0)
            { 
                Image logo = new Image { ImageContent = ConvertToBytes(logoFile),ContentType= logoFile.ContentType,FileName=logoFile.FileName, DateCreated = DateTime.Now, DateLastUpdated = DateTime.Now };
                sponsor.Logo = logo;
                
            }

            if (BannerFile != null && BannerFile.ContentLength >0)
            {
                Image banner = new Image { ImageContent = ConvertToBytes(BannerFile), ContentType = BannerFile.ContentType, FileName = BannerFile.FileName, DateCreated = DateTime.Now, DateLastUpdated = DateTime.Now };
                sponsor.Banner = banner;

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

        public Sponsor GetSponsor(int Id, AppContext db)
        {
            Sponsor sponsor = db.Sponsors.Include(a => a.Logo).Include(b=>b.Banner).SingleOrDefault(s => s.Id == Id);

            return sponsor;
        }

        public List<Sponsor> GetSponsors(AppContext db,bool activeOnly)
        {
            return db.Sponsors.Include(l => l.Banner).Include(b => b.Logo).Where(s => s.Archived == activeOnly).ToList();
        }
    }
}