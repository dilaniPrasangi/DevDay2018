using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TIQRI.Devday.Models;

namespace TIQRI.Devday.Context

{
    public class AppContext: DbContext
    {

        public AppContext() : base("DefaultConnection")
        {
        }
 
        //creating tables relevant from entitiy framework
        public DbSet<TShirtSize> TShirtSizes { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}