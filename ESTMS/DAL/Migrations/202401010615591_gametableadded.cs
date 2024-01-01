namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gametableadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        GameName = c.String(nullable: false, maxLength: 50),
                        GameWebsite = c.String(maxLength: 100),
                        GameLogo = c.String(nullable: false, maxLength: 100),
                        Genre = c.String(nullable: false, maxLength: 50),
                        Platform = c.String(nullable: false, maxLength: 50),
                        GameRules = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Games");
        }
    }
}
