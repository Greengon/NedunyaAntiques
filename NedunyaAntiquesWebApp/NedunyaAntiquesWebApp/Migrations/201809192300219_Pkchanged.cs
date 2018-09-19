namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pkchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Transactions", "CustomerEmail", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Email");
            AddForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers", "Email");
            DropColumn("dbo.Customers", "CustomerId");
            DropColumn("dbo.Transactions", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Transactions", "CustomerEmail");
            AddPrimaryKey("dbo.Customers", "Email");
            AddForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers", "Email");
        }
    }
}
