using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIQRI.Devday.Context;

namespace TIQRI.Devday.Controllers
{
    public class ValidationController : Controller
    {
        private AppContext db = new AppContext();

        // GET: Validation
        public ActionResult Index()
        {
            return View();
        }       

        //To check only user type   
        [HttpGet]
        public JsonResult IsUserTypeExist(string userTypeName)
        {
            var userTypesArr = db.UserTypes.ToList();
            return Json(!userTypesArr.Any(t => t.UserTypeName == userTypeName), JsonRequestBehavior.AllowGet);
        }

        //To check only one status exists   
        [HttpGet]
        public JsonResult IsStatusNameExist(string userStatusName)
        {
            var userStatusArr = db.UserStatuses.ToList();            
            // Returns "false" (i.e., "not valid") if a status with the specified name already exists. 
            return Json(!userStatusArr.Any(s => s.UserStatusName == userStatusName), JsonRequestBehavior.AllowGet);
        }

        //To check only tshirt size   
        [HttpGet]
        public JsonResult IsTshirtSizeExist(string size)
        {
            var sizesArr = db.TShirtSizes.ToList();
            return Json(!sizesArr.Any(s => s.Size == size), JsonRequestBehavior.AllowGet);
        }

        //For check both at a time .mailid and empName.   
        // [HttpGet]
        // public JsonResult IsNameandMailExist(string firstName, string lastName, string email)
        //   {

        // bool isExist = EmployeeStaticData.UserList.Where(u => u.EmpName.ToLowerInvariant().Equals(Empname.ToLower()) && u.EmpMail.ToLowerInvariant().Equals(EmpMail.ToLower())).FirstOrDefault() != null;
        //  return Json(!isExist, JsonRequestBehavior.AllowGet);
        // }
    }
}
