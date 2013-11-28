namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Studies", "ClientUserName", "dbo.Clients");
            DropIndex("dbo.Studies", new[] { "ClientUserName" });
            AddColumn("dbo.Studies", "EmployeeUserName", c => c.String(maxLength: 128));
            AddColumn("dbo.Studies", "Client_UserName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Studies", "EmployeeUserName");
            CreateIndex("dbo.Studies", "Client_UserName");
            AddForeignKey("dbo.Studies", "EmployeeUserName", "dbo.Clients", "UserName");
            AddForeignKey("dbo.Studies", "Client_UserName", "dbo.Clients", "UserName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Studies", "Client_UserName", "dbo.Clients");
            DropForeignKey("dbo.Studies", "EmployeeUserName", "dbo.Clients");
            DropIndex("dbo.Studies", new[] { "Client_UserName" });
            DropIndex("dbo.Studies", new[] { "EmployeeUserName" });
            DropColumn("dbo.Studies", "Client_UserName");
            DropColumn("dbo.Studies", "EmployeeUserName");
            CreateIndex("dbo.Studies", "ClientUserName");
            AddForeignKey("dbo.Studies", "ClientUserName", "dbo.Clients", "UserName");
        }
    }
}
