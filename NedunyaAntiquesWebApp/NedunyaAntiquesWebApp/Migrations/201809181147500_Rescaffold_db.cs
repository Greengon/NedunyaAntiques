namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rescaffold_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransacDate = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            AddColumn("dbo.Products", "SubCategory", c => c.String());
            AddColumn("dbo.Products", "Transaction_Id", c => c.Int());
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Products", "Transaction_Id");
            AddForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions", "Id");
            DropColumn("dbo.Products", "Images");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Images", c => c.String());
            DropForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "Transaction_Id" });
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Products", "Transaction_Id");
            DropColumn("dbo.Products", "SubCategory");
            DropTable("dbo.Transactions");
        }
    }
}
