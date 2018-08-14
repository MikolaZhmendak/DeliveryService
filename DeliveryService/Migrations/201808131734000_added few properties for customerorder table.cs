namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfewpropertiesforcustomerordertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "Acept", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerOrders", "Finished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerOrders", "Finished");
            DropColumn("dbo.CustomerOrders", "Acept");
        }
    }
}
