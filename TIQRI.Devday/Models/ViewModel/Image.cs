using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models.ViewModel
{
    public class Image:EntityBase
    {
        [Required]
        public byte[] ImageContent { get; set; }
       
        public string FileName { get; set; }

        [Required]
        public string ContentType { get; set; }
    }
}