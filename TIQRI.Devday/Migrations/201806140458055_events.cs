namespace TIQRI.Devday.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class events : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventStartTime", c => c.DateTime());
            AddColumn("dbo.Events", "EventEndTime", c => c.DateTime());
            AddColumn("dbo.Events", "Venue", c => c.String());
            AddColumn("dbo.Events", "Description", c => c.String());
            DropColumn("dbo.Events", "Test");
            DropColumn("dbo.Events", "EventDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventDate", c => c.DateTime());
            AddColumn("dbo.Events", "Test", c => c.String());
            DropColumn("dbo.Events", "Description");
            DropColumn("dbo.Events", "Venue");
            DropColumn("dbo.Events", "EventEndTime");
            DropColumn("dbo.Events", "EventStartTime");
        }
    }
}
