namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BackgroundChecks",
                c => new
                    {
                        BackgroundId = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(),
                        Date_of_Birth = c.DateTime(nullable: false),
                        Ssn = c.Long(nullable: false),
                        VehicleType = c.String(),
                        VehicleYear = c.Int(nullable: false),
                        DrivingLicence = c.Long(nullable: false),
                        LicenceState = c.String(),
                        InsuranceProvider = c.String(),
                        ExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BackgroundId)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        PhoneNumber = c.Long(nullable: false),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardId = c.Int(nullable: false, identity: true),
                        CreditCardNumber = c.Int(nullable: false),
                        CardType = c.Int(nullable: false),
                        ExparationDate = c.Int(nullable: false),
                        CVC = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        PhoneNumber = c.Long(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        RestaurantName = c.String(),
                        ItemOrdered = c.String(),
                        Quantity = c.Int(nullable: false),
                        Date_of_Order = c.DateTime(),
                        CurbeSide = c.Boolean(nullable: false),
                        WalkIn = c.Boolean(nullable: false),
                        Tips = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.FirstName);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.CustomerOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BackgroundChecks", "DriverId", "dbo.Drivers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CustomerOrders", new[] { "CustomerId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropIndex("dbo.BackgroundChecks", new[] { "DriverId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Employers");
            DropTable("dbo.CustomerOrders");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditCards");
            DropTable("dbo.Drivers");
            DropTable("dbo.BackgroundChecks");
        }
    }
}
