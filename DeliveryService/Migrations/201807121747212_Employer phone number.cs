namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employerphonenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employers", "LastName", c => c.String());
            AlterColumn("dbo.Drivers", "PhoneNumber", c => c.Long(nullable: false));
            AlterColumn("dbo.Employers", "PhoneNumber", c => c.Long(nullable: false));
            DropColumn("dbo.Employers", "LasttName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "LasttName", c => c.String());
            AlterColumn("dbo.Employers", "PhoneNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Drivers", "PhoneNumber", c => c.String());
            DropColumn("dbo.Employers", "LastName");
        }
    }
}
