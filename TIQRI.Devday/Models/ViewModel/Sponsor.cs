using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TIQRI.Devday.Models.ViewModel
{
    public class Sponsor:EntityBase
    {
        //private readonly List<Events> eventItemsList;

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string ContactNumber{get;set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Image Logo { get; set; }
        public Image Banner { get; set; }

        public Event Event { get; set; }
       

    }
}