namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taketipsfromcustomerordertable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerOrders", "Tips");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "Tips", c => c.Int(nullable: false));
        }
    }
}
