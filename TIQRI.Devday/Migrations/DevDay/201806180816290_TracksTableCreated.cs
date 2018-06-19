namespace TIQRI.Devday.Migrations.DevDay
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TracksTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackName = c.String(),
                        Description = c.String(),
                        EventId = c.String(),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventStartTime = c.DateTime(),
                        EventEndTime = c.DateTime(),
                        Venue = c.String(),
                        Description = c.String(),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "Event_Id", "dbo.Events");
            DropIndex("dbo.Tracks", new[] { "Event_Id" });
            DropTable("dbo.Events");
            DropTable("dbo.Tracks");
        }
    }
}
