#region Using Statements

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models;

#endregion

namespace TIQRI.Devday.Services
{
    /// <summary>
    /// User type class
    /// </summary>
    public class UserTypeService
    {
        #region Public Methods

        public bool CreateUserType(UserType model, AppContext db)
        {
            model.Archived = false;
            model.DateCreated = DateTime.Now;
            model.DateLastUpdated = DateTime.Now;
            model.UserCreated = System.Web.HttpContext.Current.User.Identity.Name;
            db.UserTypes.Add(model);
            db.SaveChanges();

            return true;
        }

        public bool EditUserType(UserType model, AppContext db)
        {
            db.Entry(model).State = EntityState.Modified;
            model.DateLastUpdated = DateTime.Now;
            model.UserLastUpdated = System.Web.HttpContext.Current.User.Identity.Name;       
            db.SaveChanges();
            return true;
        }

        public bool DeleteUserType(int id, AppContext db)
        {
            UserType type = db.UserTypes.Find(id);
            db.UserTypes.Remove(type);
            db.SaveChanges();

            return true;
        }

        #endregion
    }
}