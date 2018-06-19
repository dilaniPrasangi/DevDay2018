using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TIQRI.Devday.Models
{
    public class Image:EntityBase
    {
        public byte[] ImageContent { get; set; }
    }
}