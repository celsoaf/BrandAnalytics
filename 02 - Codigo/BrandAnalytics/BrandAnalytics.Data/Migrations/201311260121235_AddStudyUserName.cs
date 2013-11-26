namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudyUserName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Studies", "Client_UserName", "dbo.Clients");
            DropIndex("dbo.Studies", new[] { "Client_UserName" });
            AddColumn("dbo.Studies", "ClientUserName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Studies", "ClientUserName");
            AddForeignKey("dbo.Studies", "ClientUserName", "dbo.Clients", "UserName");
            DropColumn("dbo.Studies", "Client_UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Studies", "Client_UserName", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Studies", "ClientUserName", "dbo.Clients");
            DropIndex("dbo.Studies", new[] { "ClientUserName" });
            DropColumn("dbo.Studies", "ClientUserName");
            CreateIndex("dbo.Studies", "Client_UserName");
            AddForeignKey("dbo.Studies", "Client_UserName", "dbo.Clients", "UserName");
        }
    }
}
