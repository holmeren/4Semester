namespace Vittigheder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jokes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        JokeString = c.String(),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagString = c.String(),
                        Joke_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jokes", t => t.Joke_Id)
                .Index(t => t.Joke_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tags", "Joke_Id", "dbo.Jokes");
            DropIndex("dbo.Tags", new[] { "Joke_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Jokes");
        }
    }
}
