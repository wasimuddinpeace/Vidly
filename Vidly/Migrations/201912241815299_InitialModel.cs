namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Environments",
                c => new
                    {
                        EnvironmentId = c.Int(nullable: false, identity: true),
                        EnvironmentName = c.String(),
                    })
                .PrimaryKey(t => t.EnvironmentId);
            
            CreateTable(
                "dbo.GeosForProds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeoName = c.String(),
                        EnvironmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Environments", t => t.EnvironmentId, cascadeDelete: true)
                .Index(t => t.EnvironmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeosForProds", "EnvironmentId", "dbo.Environments");
            DropIndex("dbo.GeosForProds", new[] { "EnvironmentId" });
            DropTable("dbo.GeosForProds");
            DropTable("dbo.Environments");
        }
    }
}
