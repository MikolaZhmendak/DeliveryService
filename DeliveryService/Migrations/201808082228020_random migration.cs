namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class randommigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrders", "Tips", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerOrders", "Tips");
        }
    }
}
