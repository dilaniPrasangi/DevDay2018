using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TIQRI.Devday.Models;
using TIQRI.Devday.Models.ViewModel;

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
        public DbSet<Image> Images { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackQuestion> FeedbackQuestions { get; set; }
        public DbSet<FeedbackType> FeedbackTypes { get; set; }
    }
}