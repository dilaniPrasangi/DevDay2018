using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class User : EntityBase
    {
      
        public string UserEmail { get; set; }
        public double SecurityCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string UserDescription { get; set; }
        
        //foregin keys
        public int UserStatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public virtual int TShirtSizeId { get; set; }
        public virtual TShirtSize TShirtSize { get; set; }
    }
}