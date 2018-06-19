using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class Track:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Event Event { get; set; }
    }
}