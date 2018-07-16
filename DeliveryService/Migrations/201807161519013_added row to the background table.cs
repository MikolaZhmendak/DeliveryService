namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedrowtothebackgroundtable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BackgroundChecks", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BackgroundChecks", "ExpirationDate", c => c.Int(nullable: false));
        }
    }
}
