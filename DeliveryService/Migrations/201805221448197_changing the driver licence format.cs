namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingthedriverlicenceformat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DrivingLicence", c => c.Long(nullable: false));
            AlterColumn("dbo.Vehicles", "LicenceState", c => c.String(nullable: false));
            DropColumn("dbo.Vehicles", "DrivingLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Vehicles", "LicenceState", c => c.String());
            DropColumn("dbo.Vehicles", "DrivingLicence");
        }
    }
}
