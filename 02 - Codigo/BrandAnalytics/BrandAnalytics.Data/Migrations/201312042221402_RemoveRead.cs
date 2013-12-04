namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRead : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "Read");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "Read", c => c.Boolean(nullable: false));
        }
    }
}
