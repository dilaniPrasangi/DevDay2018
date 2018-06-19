using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models.ViewModel
{
    public class Track:EntityBase
    {
        public string TrackName { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
    }
}