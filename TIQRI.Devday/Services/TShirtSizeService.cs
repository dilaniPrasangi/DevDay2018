using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TIQRI.Devday.Context;
using TIQRI.Devday.Models.ViewModel;

namespace TIQRI.Devday.Services
{
    public class TShirtSizeService
    {
        #region Public Methods

        public bool CreateUserTSize(TShirtSize model, AppContext db)
        {
            model.Archived = false;
            model.DateCreated = DateTime.Now;
            model.DateLastUpdated = DateTime.Now;
            model.UserCreated = System.Web.HttpContext.Current.User.Identity.Name;
            db.TShirtSizes.Add(model);
            db.SaveChanges();

            return true;
        }

        public bool EditUserTSize(TShirtSize model, AppContext db)
        {
            db.Entry(model).State = EntityState.Modified;
            model.DateLastUpdated = DateTime.Now;
            model.UserLastUpdated = System.Web.HttpContext.Current.User.Identity.Name;
            db.SaveChanges();

            return true;
        }

        public bool DeleteUserTSize(int id, AppContext db)
        {
            TShirtSize size = db.TShirtSizes.Find(id);
            db.TShirtSizes.Remove(size);
            db.SaveChanges();

            return true;
        }

        #endregion
    }
}