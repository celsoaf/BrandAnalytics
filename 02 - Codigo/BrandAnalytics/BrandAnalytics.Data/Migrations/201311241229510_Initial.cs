namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.Studies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mark = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                        Client_UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_UserName)
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
                        Id = c.Int(nullable: false),
                        StudyId = c.Int(nullable: false),
                        Term = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.StudyId })
                .ForeignKey("dbo.StudyReports", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Studies", "Client_UserName", "dbo.Clients");
            DropForeignKey("dbo.StudyReports", "Id", "dbo.Studies");
            DropForeignKey("dbo.StudyTermReports", "Id", "dbo.StudyReports");
            DropIndex("dbo.Studies", new[] { "Client_UserName" });
            DropIndex("dbo.StudyReports", new[] { "Id" });
            DropIndex("dbo.StudyTermReports", new[] { "Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.StudyTermReports");
            DropTable("dbo.StudyReports");
            DropTable("dbo.Studies");
            DropTable("dbo.Clients");
        }
    }
}
