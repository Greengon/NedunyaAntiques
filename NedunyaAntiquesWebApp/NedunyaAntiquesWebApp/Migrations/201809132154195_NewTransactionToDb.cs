namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTransactionToDb : DbMigration
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
            
            AddColumn("dbo.Products", "Transaction_Id", c => c.Int());
            CreateIndex("dbo.Products", "Transaction_Id");
            AddForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            DropIndex("dbo.Products", new[] { "Transaction_Id" });
            DropColumn("dbo.Products", "Transaction_Id");
            DropTable("dbo.Transactions");
        }
    }
}
