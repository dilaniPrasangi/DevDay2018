using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class TShirtSize: EntityBase
    {
        [DisplayName("T-shirt Size")]
        public string Size { get; set; }

        public virtual List<User> users { get; set; }
    }
}