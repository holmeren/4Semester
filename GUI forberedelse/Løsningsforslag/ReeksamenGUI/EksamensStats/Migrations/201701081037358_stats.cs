namespace EksamensStats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentStats",
                c => new
                    {
                        StudentStatsId = c.Int(nullable: false, identity: true),
                        Average = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StudentStatsId);
            
            AddColumn("dbo.Students", "StudentStats_StudentStatsId", c => c.Int());
            CreateIndex("dbo.Students", "StudentStats_StudentStatsId");
            AddForeignKey("dbo.Students", "StudentStats_StudentStatsId", "dbo.StudentStats", "StudentStatsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentStats_StudentStatsId", "dbo.StudentStats");
            DropIndex("dbo.Students", new[] { "StudentStats_StudentStatsId" });
            DropColumn("dbo.Students", "StudentStats_StudentStatsId");
            DropTable("dbo.StudentStats");
        }
    }
}
