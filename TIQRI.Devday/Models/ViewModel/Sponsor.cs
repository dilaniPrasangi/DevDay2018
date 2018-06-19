using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class Sponsor:EntityBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public string ContactNumber{get;set;}

        public string Email { get; set; }

        public Image Logo { get; set; }
        public Image Banner { get; set; }
    }
}