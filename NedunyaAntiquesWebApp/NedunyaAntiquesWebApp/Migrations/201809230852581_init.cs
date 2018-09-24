namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(nullable: false),
                        CityAddress = c.String(),
                        StreetAddress = c.String(),
                        HomeNum = c.Int(nullable: false),
                        AptNum = c.Int(),
                        PhoneNum = c.String(nullable: false),
                        AdvertiseSalesNotification = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        CustomerEmail = c.String(maxLength: 128),
                        Delivery = c.Boolean(nullable: false),
                        TransDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Customers", t => t.CustomerEmail)
                .Index(t => t.CustomerEmail);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentalPriceForDay = c.Decimal(precision: 18, scale: 2),
                        Substance = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        SubCategory = c.String(nullable: false),
                        Height = c.Double(),
                        Width = c.Double(),
                        Depth = c.Double(),
                        Sale = c.Boolean(nullable: false),
                        Rented = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        Transaction_TransactionId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionId)
                .Index(t => t.Transaction_TransactionId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Transaction_TransactionId", "dbo.Transactions");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Transactions", "CustomerEmail", "dbo.Customers");
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Transaction_TransactionId" });
            DropIndex("dbo.Transactions", new[] { "CustomerEmail" });
            DropTable("dbo.Images");
            DropTable("dbo.Products");
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
        }
    }
}
