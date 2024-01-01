namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SponsorTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Contact = c.String(nullable: false, maxLength: 11),
                        logo = c.String(maxLength: 100),
                        Website = c.String(maxLength: 100),
                        SponsershipTier = c.String(maxLength: 10),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sponsors", "UserId", "dbo.Users");
            DropIndex("dbo.Sponsors", new[] { "UserId" });
            DropTable("dbo.Sponsors");
        }
    }
}
