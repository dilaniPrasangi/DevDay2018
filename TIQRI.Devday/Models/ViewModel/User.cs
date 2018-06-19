using System.Collections.Generic;
using System.ComponentModel;

namespace TIQRI.Devday.Models.ViewModel
{
    public class User : EntityBase
    {
        [DisplayName("Email")]
        public string UserEmail { get; set; }
        [DisplayName("Code")]
        public double SecurityCode { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]        
        public string LastName { get; set; }
        [DisplayName("Company")]
        public string Company { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [DisplayName("Mobile")]
        public string ContactNumber { get; set; }
        [DisplayName("Description")]
        public string UserDescription { get; set; }

        //foregin keys
        [DisplayName("Status")]
        public int UserStatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        [DisplayName("Type")]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        [DisplayName("T-Shirt Size")]
        public virtual int TShirtSizeId { get; set; }
        public virtual TShirtSize TShirtSize { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}