namespace TIQRI.Devday.Migrations.DevDay
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        Event_Id = c.Int(),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.Images", t => t.Image_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.Image_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventStartTime = c.DateTime(nullable: false),
                        EventEndTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Description = c.String(),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageContent = c.Binary(),
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
                "dbo.Sponsors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Description = c.String(),
                        ContactNumber = c.String(),
                        Email = c.String(),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        Banner_Id = c.Int(),
                        Logo_Id = c.Int(),
                        Event_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.Banner_Id)
                .ForeignKey("dbo.Images", t => t.Logo_Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Banner_Id)
                .Index(t => t.Logo_Id)
                .Index(t => t.Event_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
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
                "dbo.TShirtSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserEmail = c.String(),
                        SecurityCode = c.Double(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Gender = c.String(),
                        ContactNumber = c.String(),
                        UserDescription = c.String(),
                        UserStatusId = c.Int(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                        TShirtSizeId = c.Int(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TShirtSizes", t => t.TShirtSizeId, cascadeDelete: true)
                .ForeignKey("dbo.UserStatus", t => t.UserStatusId, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserStatusId)
                .Index(t => t.UserTypeId)
                .Index(t => t.TShirtSizeId);
            
            CreateTable(
                "dbo.UserStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserStatusName = c.String(),
                        Archived = c.Boolean(nullable: false),
                        DateLastUpdated = c.DateTime(),
                        UserLastUpdated = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserTypeName = c.String(),
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
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            DropForeignKey("dbo.Users", "TShirtSizeId", "dbo.TShirtSizes");
            DropForeignKey("dbo.Tracks", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventImages", "Image_Id", "dbo.Images");
            DropForeignKey("dbo.EventImages", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Sponsors", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Sponsors", "Logo_Id", "dbo.Images");
            DropForeignKey("dbo.Sponsors", "Banner_Id", "dbo.Images");
            DropForeignKey("dbo.Images", "Event_Id", "dbo.Events");
            DropIndex("dbo.Users", new[] { "TShirtSizeId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Users", new[] { "UserStatusId" });
            DropIndex("dbo.Tracks", new[] { "Event_Id" });
            DropIndex("dbo.Sponsors", new[] { "Event_Id" });
            DropIndex("dbo.Sponsors", new[] { "Logo_Id" });
            DropIndex("dbo.Sponsors", new[] { "Banner_Id" });
            DropIndex("dbo.Images", new[] { "Event_Id" });
            DropIndex("dbo.EventImages", new[] { "Image_Id" });
            DropIndex("dbo.EventImages", new[] { "Event_Id" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserStatus");
            DropTable("dbo.Users");
            DropTable("dbo.TShirtSizes");
            DropTable("dbo.Tracks");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Images");
            DropTable("dbo.Events");
            DropTable("dbo.EventImages");
        }
    }
}
