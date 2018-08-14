namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finishordertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FinishOrders",
                c => new
                    {
                        FinishOrderId = c.Int(nullable: false, identity: true),
                        Yes = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FinishOrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FinishOrders");
        }
    }
}
