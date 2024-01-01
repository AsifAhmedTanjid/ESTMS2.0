namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teamTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 50),
                        Website = c.String(maxLength: 100),
                        Logo = c.String(nullable: false, maxLength: 100),
                        CaptainId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Players", t => t.CaptainId, cascadeDelete: true)
                .Index(t => t.CaptainId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "CaptainId", "dbo.Players");
            DropIndex("dbo.Teams", new[] { "CaptainId" });
            DropTable("dbo.Teams");
        }
    }
}
