using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TIQRI.Devday.Models
{
    public class TShirtSize: EntityBase
    {
        [DisplayName("T-shirt Size")]
        [Required]
        [Remote("IsTshirtSizeExist", "Validation", ErrorMessage = "User T-Shirt size already exists ! ")]
        public string Size { get; set; }

        public virtual List<User> users { get; set; }
    }
}