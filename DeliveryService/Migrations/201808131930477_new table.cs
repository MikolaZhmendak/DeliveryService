namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.AcceptedOrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.CustomerOrders", t => t.OrderId)
                .Index(t => t.CustomerId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcceptedOrders", "OrderId", "dbo.CustomerOrders");
            DropForeignKey("dbo.AcceptedOrders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AcceptedOrders", new[] { "OrderId" });
            DropIndex("dbo.AcceptedOrders", new[] { "CustomerId" });
            DropTable("dbo.AcceptedOrders");
        }
    }
}
