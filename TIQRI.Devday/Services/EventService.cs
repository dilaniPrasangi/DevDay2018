using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIQRI.Devday.Models;

namespace TIQRI.Devday.Services
{
    public class EventService
    {
        public bool CreateEvent(Event model, ApplicationDbContext db) {
            model.Archived = false;
            model.DateCreated = DateTime.Now;
            model.DateLastUpdated = DateTime.Now;
            //@event.UserCreated = HttpContext.cu
            db.Events.Add(model);
            db.SaveChanges();
            return true;
        }
    }
}