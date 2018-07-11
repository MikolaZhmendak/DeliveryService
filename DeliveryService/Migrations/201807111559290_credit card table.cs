namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creditcardtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardId = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.Int(nullable: false),
                        CardType = c.String(),
                        ExparationDate = c.Int(nullable: false),
                        CVC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CreditCards");
        }
    }
}
