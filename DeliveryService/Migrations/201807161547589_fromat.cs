namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fromat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BackgroundChecks", "Ssn", c => c.Long(nullable: false));
            AlterColumn("dbo.BackgroundChecks", "DrivingLicence", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BackgroundChecks", "DrivingLicence", c => c.Int(nullable: false));
            AlterColumn("dbo.BackgroundChecks", "Ssn", c => c.String());
        }
    }
}
