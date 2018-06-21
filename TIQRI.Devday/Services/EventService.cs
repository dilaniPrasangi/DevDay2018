using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models;

namespace TIQRI.Devday.Services
{
    public class EventService
    {
        public bool CreateEvent(Event model, AppContext db) {
            model.Archived = false;
            model.DateCreated = DateTime.Now;
            model.DateLastUpdated = DateTime.Now;
            //@event.UserCreated = HttpContext.cu
            db.Events.Add(model);
            db.SaveChanges();
            return true;
        }

        public bool EditEvent(Event model, AppContext db)
        {
            db.Entry(model).State = EntityState.Modified;
            model.DateLastUpdated = DateTime.Now;
            //@event.UserCreated = HttpContext.cu
            
            db.SaveChanges();
            return true;
        }

        public List<Event> GetActiveEvents(AppContext db)
        {
            return db.Events.Where(e => e.Archived.Equals(false)).ToList();
        }
    }
}