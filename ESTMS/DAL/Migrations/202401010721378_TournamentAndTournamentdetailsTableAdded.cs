namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TournamentAndTournamentdetailsTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(nullable: false),
                        MatchDate = c.DateTime(nullable: false),
                        Team1Id = c.Int(),
                        Team2Id = c.Int(),
                        WinnerTeamId = c.Int(),
                        Score = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team1Id)
                .ForeignKey("dbo.Teams", t => t.Team2Id)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.WinnerTeamId)
                .Index(t => t.TournamentId)
                .Index(t => t.Team1Id)
                .Index(t => t.Team2Id)
                .Index(t => t.WinnerTeamId);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentTitle = c.String(nullable: false, maxLength: 100),
                        TournamentLogo = c.String(nullable: false, maxLength: 100),
                        RegistrationOpenDate = c.DateTime(nullable: false),
                        RegistrationCloseDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        OrganizedBy = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        PrizePool = c.Int(nullable: false),
                        RegistrationFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Organizers", t => t.OrganizedBy, cascadeDelete: true)
                .Index(t => t.OrganizedBy)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.TournamentTeamDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TournamentId = c.Int(),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId)
                .Index(t => t.TournamentId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentTeamDetails", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentTeamDetails", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "WinnerTeamId", "dbo.Teams");
            DropForeignKey("dbo.Matches", "TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.Tournaments", "OrganizedBy", "dbo.Organizers");
            DropForeignKey("dbo.Tournaments", "GameId", "dbo.Games");
            DropForeignKey("dbo.Matches", "Team2Id", "dbo.Teams");
            DropForeignKey("dbo.Matches", "Team1Id", "dbo.Teams");
            DropIndex("dbo.TournamentTeamDetails", new[] { "TeamId" });
            DropIndex("dbo.TournamentTeamDetails", new[] { "TournamentId" });
            DropIndex("dbo.Tournaments", new[] { "GameId" });
            DropIndex("dbo.Tournaments", new[] { "OrganizedBy" });
            DropIndex("dbo.Matches", new[] { "WinnerTeamId" });
            DropIndex("dbo.Matches", new[] { "Team2Id" });
            DropIndex("dbo.Matches", new[] { "Team1Id" });
            DropIndex("dbo.Matches", new[] { "TournamentId" });
            DropTable("dbo.TournamentTeamDetails");
            DropTable("dbo.Tournaments");
            DropTable("dbo.Matches");
        }
    }
}
