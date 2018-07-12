namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class includedcustomerforeighnkeyintotheOrdertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "CustomerId", c => c.Int());
            CreateIndex("dbo.CustomerOrders", "CustomerId");
            AddForeignKey("dbo.CustomerOrders", "CustomerId", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerOrders", new[] { "CustomerId" });
            DropColumn("dbo.CustomerOrders", "CustomerId");
        }
    }
}
