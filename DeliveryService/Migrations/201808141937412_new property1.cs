namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newproperty1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropColumn("dbo.Customers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
