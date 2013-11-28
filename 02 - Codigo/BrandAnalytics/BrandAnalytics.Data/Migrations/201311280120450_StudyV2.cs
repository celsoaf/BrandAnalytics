namespace BrandAnalytics.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudyV2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.StudyTermReports", "Id", "dbo.StudyReports");
            DropIndex("dbo.StudyTermReports", new[] { "Id" });
            CreateTable(
                "dbo.StudyTopics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StudyId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Id, t.StudyId })
                .ForeignKey("dbo.Studies", t => t.StudyId, cascadeDelete: true)
                .Index(t => t.StudyId);
            
            AddColumn("dbo.Studies", "Duration", c => c.Time(precision: 7));
            CreateIndex("dbo.StudyTermReports", "StudyId");
            AddForeignKey("dbo.StudyTermReports", "StudyId", "dbo.StudyReports", "Id", cascadeDelete: true);
            DropColumn("dbo.Studies", "Start");
            DropColumn("dbo.Studies", "End");
            DropTable("dbo.Topics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Studies", "End", c => c.DateTime());
            AddColumn("dbo.Studies", "Start", c => c.DateTime());
            DropForeignKey("dbo.StudyTermReports", "StudyId", "dbo.StudyReports");
            DropForeignKey("dbo.StudyTopics", "StudyId", "dbo.Studies");
            DropIndex("dbo.StudyTermReports", new[] { "StudyId" });
            DropIndex("dbo.StudyTopics", new[] { "StudyId" });
            DropColumn("dbo.Studies", "Duration");
            DropTable("dbo.StudyTopics");
            CreateIndex("dbo.StudyTermReports", "Id");
            AddForeignKey("dbo.StudyTermReports", "Id", "dbo.StudyReports", "Id", cascadeDelete: true);
        }
    }
}
