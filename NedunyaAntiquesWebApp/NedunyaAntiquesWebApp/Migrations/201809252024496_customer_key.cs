namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer_key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomerEmail", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Email");
            AddForeignKey("dbo.Transactions", "CustomerEmail", "dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomerEmail", "dbo.Customers");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Email");
            AddForeignKey("dbo.Transactions", "CustomerEmail", "dbo.Customers", "Email");
        }
    }
}
