using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TIQRI.Devday.Models
{
    public class UserStatus : EntityBase
    {
        [DisplayName("User Status")]
        [Required]
        [Remote("IsStatusNameExist", "Validation", ErrorMessage = "User status already exists! ")]
        public string UserStatusName { get; set; }

        public virtual List<User> users { get; set; }
    }
}