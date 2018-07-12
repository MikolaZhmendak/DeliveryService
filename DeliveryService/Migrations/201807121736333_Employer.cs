namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LasttName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FirstName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employers");
        }
    }
}
