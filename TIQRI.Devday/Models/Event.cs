using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class Event : EntityBase
    {
        public string Name { get; set; }

        [DisplayName("Start Time")]
        public DateTime? EventStartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime? EventEndTime { get; set; }

        public string Venue { get; set; }

        public string Description { get; set; }

        public List<Track> Tracks { get; set; }
    }
}