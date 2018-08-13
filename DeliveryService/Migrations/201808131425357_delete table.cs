namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.OrderDriverViews");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDriverViews",
                c => new
                    {
                        OrderDriverViewID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                        RestaurantName = c.String(),
                        ItemOrdered = c.String(),
                        Quantity = c.Int(nullable: false),
                        CurbeSide = c.Boolean(nullable: false),
                        WalkIn = c.Boolean(nullable: false),
                        Tips = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDriverViewID);
            
        }
    }
}
