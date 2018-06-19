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
    public class UserService
    {
        #region Public Methods

        public bool CreateUser(User model, AppContext db)
        {
            model.Archived = false;
            model.DateCreated = DateTime.Now;
            model.DateLastUpdated = DateTime.Now;
            model.UserCreated = System.Web.HttpContext.Current.User.Identity.Name;
            db.Users.Add(model);
            db.SaveChanges();

            return true;
        }

        public bool EditUser(User model, AppContext db)
        {
            db.Entry(model).State = EntityState.Modified;
            model.DateLastUpdated = DateTime.Now;
            model.UserLastUpdated = System.Web.HttpContext.Current.User.Identity.Name;
            db.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id, AppContext db)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();

            return true;
        }

        #endregion
    }
}