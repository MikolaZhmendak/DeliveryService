namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "FinishOrderId", c => c.Int());
            CreateIndex("dbo.CustomerOrders", "FinishOrderId");
            AddForeignKey("dbo.CustomerOrders", "FinishOrderId", "dbo.FinishOrders", "FinishOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrders", "FinishOrderId", "dbo.FinishOrders");
            DropIndex("dbo.CustomerOrders", new[] { "FinishOrderId" });
            DropColumn("dbo.CustomerOrders", "FinishOrderId");
        }
    }
}
