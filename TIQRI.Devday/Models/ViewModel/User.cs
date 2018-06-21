using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TIQRI.Devday.Models
{
    public class User : EntityBase
    {
        [DisplayName("Email")]   
        [Required]
        [Key]
        public string UserEmail { get; set; }  
             
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; }      

        [DisplayName("Company")]
        public string Company { get; set; }

        [DisplayName("Code")]
        public double SecurityCode { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Contact No ")]
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
    }
}