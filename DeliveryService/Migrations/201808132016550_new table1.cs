namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AcceptedOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.AcceptedOrders", "OrderId", "dbo.CustomerOrders");
            DropIndex("dbo.AcceptedOrders", new[] { "CustomerId" });
            DropIndex("dbo.AcceptedOrders", new[] { "OrderId" });
            CreateTable(
                "dbo.AccetpOrders",
                c => new
                    {
                        AccetpOrderId = c.Int(nullable: false, identity: true),
                        Yes = c.Boolean(nullable: false),
                        No = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccetpOrderId);
            
            DropTable("dbo.AcceptedOrders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AcceptedOrders",
                c => new
                    {
                        AcceptedOrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        OrderId = c.Int(),
                        Yes = c.Boolean(nullable: false),
                        No = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AcceptedOrderId);
            
            DropTable("dbo.AccetpOrders");
            CreateIndex("dbo.AcceptedOrders", "OrderId");
            CreateIndex("dbo.AcceptedOrders", "CustomerId");
            AddForeignKey("dbo.AcceptedOrders", "OrderId", "dbo.CustomerOrders", "OrderId");
            AddForeignKey("dbo.AcceptedOrders", "CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
