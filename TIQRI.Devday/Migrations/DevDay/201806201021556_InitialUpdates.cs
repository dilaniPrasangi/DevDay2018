namespace TIQRI.Devday.Migrations.DevDay
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tracks", "Name", c => c.String());
            AlterColumn("dbo.TShirtSizes", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.UserStatus", "UserStatusName", c => c.String(nullable: false));
            AlterColumn("dbo.UserTypes", "UserTypeName", c => c.String(nullable: false));
            DropColumn("dbo.Tracks", "TrackName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tracks", "TrackName", c => c.String());
            AlterColumn("dbo.UserTypes", "UserTypeName", c => c.String());
            AlterColumn("dbo.UserStatus", "UserStatusName", c => c.String());
            AlterColumn("dbo.TShirtSizes", "Size", c => c.String());
            DropColumn("dbo.Tracks", "Name");
        }
    }
}
