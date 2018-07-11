namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insurancetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsuranceInfromations",
                c => new
                    {
                        InsuranceInformationId = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(),
                        InsuranceProvider = c.String(),
                        Expiration_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.InsuranceInformationId)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .Index(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InsuranceInfromations", "DriverId", "dbo.Drivers");
            DropIndex("dbo.InsuranceInfromations", new[] { "DriverId" });
            DropTable("dbo.InsuranceInfromations");
        }
    }
}
