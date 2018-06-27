namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordertableupdrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        RestaurantName = c.String(),
                        ItemOrdered = c.String(),
                        Quantity = c.Int(nullable: false),
                        Date_of_Order = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerOrders");
        }
    }
}
