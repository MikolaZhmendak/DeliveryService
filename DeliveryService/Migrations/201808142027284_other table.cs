namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class othertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrderViewModels",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.Long(nullable: false),
                        RestaurantName = c.String(),
                        ItemOrdered = c.String(),
                        Quantity = c.Int(nullable: false),
                        Date_of_Order = c.DateTime(),
                        CurbeSide = c.Boolean(nullable: false),
                        WalkIn = c.Boolean(nullable: false),
                        Tips = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrderViewModels", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerOrderViewModels", new[] { "CustomerId" });
            DropTable("dbo.CustomerOrderViewModels");
        }
    }
}
