namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Body = c.String(),
                        Read = c.Boolean(nullable: false),
                        Client_UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_UserName)
                .Index(t => t.Client_UserName);
            
            CreateTable(
                "dbo.Studies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Duration = c.Time(precision: 7),
                        Employee_UserName = c.String(maxLength: 128),
                        Client_UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Employee_UserName)
                .ForeignKey("dbo.Clients", t => t.Client_UserName, cascadeDelete: true)
                .Index(t => t.Employee_UserName)
                .Index(t => t.Client_UserName);
            
            CreateTable(
                "dbo.StudyReports",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Tweets = c.Int(nullable: false),
                        Authors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Studies", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.StudyTermReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudyId = c.Int(nullable: false),
                        Term = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyReports", t => t.StudyId, cascadeDelete: true)
                .Index(t => t.StudyId);
            
            CreateTable(
                "dbo.StudyTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudyId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Studies", t => t.StudyId, cascadeDelete: true)
                .Index(t => t.StudyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Studies", "Client_UserName", "dbo.Clients");
            DropForeignKey("dbo.StudyTopics", "StudyId", "dbo.Studies");
            DropForeignKey("dbo.StudyReports", "Id", "dbo.Studies");
            DropForeignKey("dbo.StudyTermReports", "StudyId", "dbo.StudyReports");
            DropForeignKey("dbo.Studies", "Employee_UserName", "dbo.Clients");
            DropForeignKey("dbo.Notifications", "Client_UserName", "dbo.Clients");
            DropIndex("dbo.Studies", new[] { "Client_UserName" });
            DropIndex("dbo.StudyTopics", new[] { "StudyId" });
            DropIndex("dbo.StudyReports", new[] { "Id" });
            DropIndex("dbo.StudyTermReports", new[] { "StudyId" });
            DropIndex("dbo.Studies", new[] { "Employee_UserName" });
            DropIndex("dbo.Notifications", new[] { "Client_UserName" });
            DropTable("dbo.StudyTopics");
            DropTable("dbo.StudyTermReports");
            DropTable("dbo.StudyReports");
            DropTable("dbo.Studies");
            DropTable("dbo.Notifications");
            DropTable("dbo.Clients");
        }
    }
}
