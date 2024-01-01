namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Contact = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 10),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "UserId", "dbo.Users");
            DropIndex("dbo.Players", new[] { "UserId" });
            DropTable("dbo.Players");
        }
    }
}
