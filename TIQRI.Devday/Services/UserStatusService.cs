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
    public class UserStatusService
    {
        #region Public Methods

        public bool CreateUserStatus(UserStatus model, AppContext db)
        {
            model.Archived = false;
            model.DateCreated = DateTime.Now;
            model.DateLastUpdated = DateTime.Now;
            model.UserCreated = System.Web.HttpContext.Current.User.Identity.Name;
            db.UserStatuses.Add(model);
            db.SaveChanges();

            return true;
        }

        public bool EditUserStatus(UserStatus model, AppContext db)
        {
            db.Entry(model).State = EntityState.Modified;
            model.DateLastUpdated = DateTime.Now;
            model.UserLastUpdated = System.Web.HttpContext.Current.User.Identity.Name;
            db.SaveChanges();
            return true;
        }

        public bool DeleteUserStatus(int id, AppContext db)
        {
            UserStatus status = db.UserStatuses.Find(id);
            db.UserStatuses.Remove(status);
            db.SaveChanges();

            return true;
        }

        #endregion
    }
}