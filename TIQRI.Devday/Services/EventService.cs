using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIQRI.Devday.Models;

namespace TIQRI.Devday.Services
{
    public class EventService
    {
        public bool CreateEvent(Event model) {
            //var context = new ApplicationDbContext();
            //context.Events.Add(model);
            //context.SaveChanges();
            return true;
        }
    }
}