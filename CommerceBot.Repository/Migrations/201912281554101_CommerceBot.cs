namespace CommerceBot.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommerceBot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabana",
                c => new
                    {
                        CabanaID = c.Int(nullable: false),
                        CabanaName = c.String(),
                        LocationID = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        NumberOfReviews = c.Int(nullable: false),
                        PriceStarting = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CabanaID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cabana", "LocationID", "dbo.Location");
            DropIndex("dbo.Cabana", new[] { "LocationID" });
            DropTable("dbo.Location");
            DropTable("dbo.Cabana");
        }
    }
}
