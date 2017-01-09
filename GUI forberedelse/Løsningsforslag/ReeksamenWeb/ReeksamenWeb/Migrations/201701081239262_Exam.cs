namespace ReeksamenWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Exam : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EksamensSets",
                c => new
                    {
                        EksamensSetId = c.Int(nullable: false, identity: true),
                        Fag = c.String(),
                        Termin = c.DateTime(nullable: false),
                        StudieNummer = c.String(),
                        Karakter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EksamensSetId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EksamensSets");
        }
    }
}
