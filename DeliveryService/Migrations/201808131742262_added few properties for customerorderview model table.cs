namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfewpropertiesforcustomerorderviewmodeltable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerOrders", "Acept");
            DropColumn("dbo.CustomerOrders", "Finished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "Finished", c => c.Boolean(nullable: false));
            AddColumn("dbo.CustomerOrders", "Acept", c => c.Boolean(nullable: false));
        }
    }
}
