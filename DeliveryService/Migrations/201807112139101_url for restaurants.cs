namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urlforrestaurants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Url");
        }
    }
}
