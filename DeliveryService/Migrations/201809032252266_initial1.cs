namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrderViewModels", "FinishOrderId", c => c.Int());
            CreateIndex("dbo.CustomerOrderViewModels", "FinishOrderId");
            AddForeignKey("dbo.CustomerOrderViewModels", "FinishOrderId", "dbo.FinishOrders", "FinishOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrderViewModels", "FinishOrderId", "dbo.FinishOrders");
            DropIndex("dbo.CustomerOrderViewModels", new[] { "FinishOrderId" });
            DropColumn("dbo.CustomerOrderViewModels", "FinishOrderId");
        }
    }
}
