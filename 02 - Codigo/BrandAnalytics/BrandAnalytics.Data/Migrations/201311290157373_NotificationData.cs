namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotificationData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Created");
        }
    }
}
