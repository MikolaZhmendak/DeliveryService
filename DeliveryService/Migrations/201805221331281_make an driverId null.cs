namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makeandriverIdnull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers");
            DropIndex("dbo.BackgroundChecks", new[] { "DriverId" });
            AlterColumn("dbo.BackgroundChecks", "DriverId", c => c.Int());
            CreateIndex("dbo.BackgroundChecks", "DriverId");
            AddForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers", "DriverId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers");
            DropIndex("dbo.BackgroundChecks", new[] { "DriverId" });
            AlterColumn("dbo.BackgroundChecks", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.BackgroundChecks", "DriverId");
            AddForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: true);
        }
    }
}
