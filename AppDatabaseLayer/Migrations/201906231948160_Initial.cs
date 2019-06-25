namespace AppDatabaseLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        DateStarted = c.DateTime(storeType: "date"),
                        DateCompleted = c.DateTime(storeType: "date"),
                        CandidateID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Candidates", t => t.CandidateID)
                .Index(t => t.CandidateID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "CandidateID", "dbo.Candidates");
            DropIndex("dbo.Qualifications", new[] { "CandidateID" });
            DropTable("dbo.Qualifications");
            DropTable("dbo.Candidates");
        }
    }
}
