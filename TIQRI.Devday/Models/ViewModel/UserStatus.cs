using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models.ViewModel
{
    public class UserStatus : EntityBase
    {
        [DisplayName("User Status")]
        public string UserStatusName { get; set; }

        public virtual List<User> users { get; set; }
    }
}