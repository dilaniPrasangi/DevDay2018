using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class Event : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Start Time")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EventStartTime { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        [DisplayName("End Time")]
        
        public DateTime EventEndTime { get; set; }

        [Required]
        public string Venue { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<Sponsor> Sponsors { get; set; }

        public List<Image> Images { get; set; }

        public List<Track> Tracks { get; set; }
    }
}