namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforeignkey1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FinishOrders", "OrderId", c => c.Int());
            CreateIndex("dbo.FinishOrders", "OrderId");
            AddForeignKey("dbo.FinishOrders", "OrderId", "dbo.CustomerOrders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FinishOrders", "OrderId", "dbo.CustomerOrders");
            DropIndex("dbo.FinishOrders", new[] { "OrderId" });
            DropColumn("dbo.FinishOrders", "OrderId");
        }
    }
}
