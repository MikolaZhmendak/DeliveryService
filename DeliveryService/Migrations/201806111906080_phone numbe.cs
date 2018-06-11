namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonenumbe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "PhoneNumber", c => c.Long(nullable: false));
        }
    }
}
