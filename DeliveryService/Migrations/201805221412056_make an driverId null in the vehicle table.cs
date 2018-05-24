namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeandriverIdnullinthevehicletable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            AlterColumn("dbo.Vehicles", "DriverId", c => c.Int());
            CreateIndex("dbo.Vehicles", "DriverId");
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers", "DriverId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            AlterColumn("dbo.Vehicles", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "DriverId");
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: true);
        }
    }
}
