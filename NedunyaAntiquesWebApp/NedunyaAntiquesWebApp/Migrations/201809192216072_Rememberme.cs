namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rememberme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomerId" });
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "RememberMe", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "Customer_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Email");
            CreateIndex("dbo.Transactions", "Customer_Email");
            AddForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Customer_Email" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "ConfirmPassword", c => c.String());
            DropColumn("dbo.Transactions", "Customer_Email");
            DropColumn("dbo.Customers", "RememberMe");
            AddPrimaryKey("dbo.Customers", "CustomerId");
            CreateIndex("dbo.Transactions", "CustomerId");
            AddForeignKey("dbo.Transactions", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
