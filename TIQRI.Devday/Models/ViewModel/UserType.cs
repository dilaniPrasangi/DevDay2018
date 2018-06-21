using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TIQRI.Devday.Models.ViewModel
{
    public class UserType : EntityBase
    {
        [DisplayName("User Type")]
        [Required]
        [Remote("IsUserTypeExist", "Validation", ErrorMessage = "user type already exist! ")]
        public string UserTypeName { get; set; }

        public virtual List<User> users { get; set; }
    }
}