namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ssn : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BackgroundChecks", "Ssn", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BackgroundChecks", "Ssn", c => c.Long(nullable: false));
        }
    }
}
