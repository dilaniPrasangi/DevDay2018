using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Controllers.API
{
    public class LoginController : ApiController
    {
        [Authorize]
        public bool CreateEvent(Event model) {
            return true;
        }
    }
}
