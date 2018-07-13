namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.InsuranceInfromations", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.BackgroundChecks", new[] { "DriverId" });
            DropIndex("dbo.InsuranceInfromations", new[] { "DriverId" });
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            AlterColumn("dbo.BackgroundChecks", "DriverId", c => c.Int(nullable: false));
            AlterColumn("dbo.InsuranceInfromations", "DriverId", c => c.Int(nullable: false));
            AlterColumn("dbo.Vehicles", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.BackgroundChecks", "DriverId");
            CreateIndex("dbo.InsuranceInfromations", "DriverId");
            CreateIndex("dbo.Vehicles", "DriverId");
            AddForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: true);
            AddForeignKey("dbo.InsuranceInfromations", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.InsuranceInfromations", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropIndex("dbo.InsuranceInfromations", new[] { "DriverId" });
            DropIndex("dbo.BackgroundChecks", new[] { "DriverId" });
            AlterColumn("dbo.Vehicles", "DriverId", c => c.Int());
            AlterColumn("dbo.InsuranceInfromations", "DriverId", c => c.Int());
            AlterColumn("dbo.BackgroundChecks", "DriverId", c => c.Int());
            CreateIndex("dbo.Vehicles", "DriverId");
            CreateIndex("dbo.InsuranceInfromations", "DriverId");
            CreateIndex("dbo.BackgroundChecks", "DriverId");
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers", "DriverId");
            AddForeignKey("dbo.InsuranceInfromations", "DriverId", "dbo.Drivers", "DriverId");
            AddForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers", "DriverId");
        }
    }
}
