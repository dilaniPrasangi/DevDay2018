using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class EventImage:EntityBase
    {
        public Event Event { get; set; }
        public Image Image { get; set; }
    }
}