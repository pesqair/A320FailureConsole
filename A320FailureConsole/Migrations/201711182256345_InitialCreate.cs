namespace A320FailureConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ACSystems",
                c => new
                    {
                        ACSystemID = c.Int(nullable: false, identity: true),
                        ACSystemIDName = c.String(nullable: false),
                        Description = c.String(),
                        DREF0prefix = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ACSystemID);
            
            CreateTable(
                "dbo.Failures",
                c => new
                    {
                        FailureID = c.Int(nullable: false, identity: true),
                        FailureName = c.String(nullable: false),
                        Description = c.String(),
                        ACSystemID = c.Int(nullable: false),
                        DREF0suffix = c.String(nullable: false),
                        FailValue = c.Single(nullable: false),
                        FixValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.FailureID)
                .ForeignKey("dbo.ACSystems", t => t.ACSystemID, cascadeDelete: true)
                .Index(t => t.ACSystemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Failures", "ACSystemID", "dbo.ACSystems");
            DropIndex("dbo.Failures", new[] { "ACSystemID" });
            DropTable("dbo.Failures");
            DropTable("dbo.ACSystems");
        }
    }
}
