namespace TIQRI.Devday.Migrations.DevDay
{
    using Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TIQRI.Devday.Context.AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DevDay";
        }

        protected override void Seed(TIQRI.Devday.Context.AppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //add sample t-shirt sizes
            context.TShirtSizes.AddOrUpdate(
                t => t.Size, ExampleData.GetTShirtSizes().ToArray());
            context.SaveChanges();

            //add sample user types
            context.UserTypes.AddOrUpdate(
                t => t.UserTypeName, ExampleData.GetUserTypes().ToArray());
            context.SaveChanges();

            //add sample user statuses
            context.UserStatuses.AddOrUpdate(
                t => t.UserStatusName, ExampleData.GetUserStatuses().ToArray());
            context.SaveChanges();

            //add sample users
            context.Users.AddOrUpdate(
                u => u.UserEmail, ExampleData.GetUsers(context).ToArray());
            context.SaveChanges();
        }
    }
}
