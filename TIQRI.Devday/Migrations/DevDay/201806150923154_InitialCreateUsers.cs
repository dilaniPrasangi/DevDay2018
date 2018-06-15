namespace TIQRI.Devday.Migrations.DevDay
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateUsers : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Users", new[] { "TShirtSizeId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Users", new[] { "UserStatusId" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserStatus");
            DropTable("dbo.Users");
            DropTable("dbo.TShirtSizes");
        }
    }
}
