namespace TIQRI.Devday.Migrations.DevDay
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "TShirtSizeId", "dbo.TShirtSizes");
            DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropPrimaryKey("dbo.TShirtSizes");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.UserStatus");
            DropPrimaryKey("dbo.UserTypes");
            AddColumn("dbo.TShirtSizes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.TShirtSizes", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.TShirtSizes", "DateLastUpdated", c => c.DateTime());
            AddColumn("dbo.TShirtSizes", "UserLastUpdated", c => c.String());
            AddColumn("dbo.TShirtSizes", "DateCreated", c => c.DateTime());
            AddColumn("dbo.TShirtSizes", "UserCreated", c => c.String());
            AddColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Users", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "DateLastUpdated", c => c.DateTime());
            AddColumn("dbo.Users", "UserLastUpdated", c => c.String());
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime());
            AddColumn("dbo.Users", "UserCreated", c => c.String());
            AddColumn("dbo.UserStatus", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserStatus", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserStatus", "DateLastUpdated", c => c.DateTime());
            AddColumn("dbo.UserStatus", "UserLastUpdated", c => c.String());
            AddColumn("dbo.UserStatus", "DateCreated", c => c.DateTime());
            AddColumn("dbo.UserStatus", "UserCreated", c => c.String());
            AddColumn("dbo.UserTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.UserTypes", "Archived", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserTypes", "DateLastUpdated", c => c.DateTime());
            AddColumn("dbo.UserTypes", "UserLastUpdated", c => c.String());
            AddColumn("dbo.UserTypes", "DateCreated", c => c.DateTime());
            AddColumn("dbo.UserTypes", "UserCreated", c => c.String());
            AlterColumn("dbo.TShirtSizes", "TShirtSizeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserStatus", "UserStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserTypes", "UserTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.TShirtSizes", "Id");
            AddPrimaryKey("dbo.Users", "Id");
            AddPrimaryKey("dbo.UserStatus", "Id");
            AddPrimaryKey("dbo.UserTypes", "Id");
            AddForeignKey("dbo.Users", "TShirtSizeId", "dbo.TShirtSizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus");
            DropForeignKey("dbo.Users", "TShirtSizeId", "dbo.TShirtSizes");
            DropPrimaryKey("dbo.UserTypes");
            DropPrimaryKey("dbo.UserStatus");
            DropPrimaryKey("dbo.Users");
            DropPrimaryKey("dbo.TShirtSizes");
            AlterColumn("dbo.UserTypes", "UserTypeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserStatus", "UserStatusId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "UserId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.TShirtSizes", "TShirtSizeId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.UserTypes", "UserCreated");
            DropColumn("dbo.UserTypes", "DateCreated");
            DropColumn("dbo.UserTypes", "UserLastUpdated");
            DropColumn("dbo.UserTypes", "DateLastUpdated");
            DropColumn("dbo.UserTypes", "Archived");
            DropColumn("dbo.UserTypes", "Id");
            DropColumn("dbo.UserStatus", "UserCreated");
            DropColumn("dbo.UserStatus", "DateCreated");
            DropColumn("dbo.UserStatus", "UserLastUpdated");
            DropColumn("dbo.UserStatus", "DateLastUpdated");
            DropColumn("dbo.UserStatus", "Archived");
            DropColumn("dbo.UserStatus", "Id");
            DropColumn("dbo.Users", "UserCreated");
            DropColumn("dbo.Users", "DateCreated");
            DropColumn("dbo.Users", "UserLastUpdated");
            DropColumn("dbo.Users", "DateLastUpdated");
            DropColumn("dbo.Users", "Archived");
            DropColumn("dbo.Users", "Id");
            DropColumn("dbo.TShirtSizes", "UserCreated");
            DropColumn("dbo.TShirtSizes", "DateCreated");
            DropColumn("dbo.TShirtSizes", "UserLastUpdated");
            DropColumn("dbo.TShirtSizes", "DateLastUpdated");
            DropColumn("dbo.TShirtSizes", "Archived");
            DropColumn("dbo.TShirtSizes", "Id");
            AddPrimaryKey("dbo.UserTypes", "UserTypeId");
            AddPrimaryKey("dbo.UserStatus", "UserStatusId");
            AddPrimaryKey("dbo.Users", "UserId");
            AddPrimaryKey("dbo.TShirtSizes", "TShirtSizeId");
            AddForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes", "UserTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "UserStatusId", "dbo.UserStatus", "UserStatusId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "TShirtSizeId", "dbo.TShirtSizes", "TShirtSizeId", cascadeDelete: true);
        }
    }
}
