namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooleanProp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Customer_Id", newName: "Customer_Email");
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Transactions", "Rented", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "Soled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Transactions", "Customer_Email", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Customers", "Email");
            CreateIndex("dbo.Transactions", "Customer_Email");
            AddForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Customer_Email", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Customer_Email" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Transactions", "Customer_Email", c => c.Int());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Transactions", "Soled");
            DropColumn("dbo.Transactions", "Rented");
            AddPrimaryKey("dbo.Customers", "Id");
            RenameColumn(table: "dbo.Transactions", name: "Customer_Email", newName: "Customer_Id");
            CreateIndex("dbo.Transactions", "Customer_Id");
            AddForeignKey("dbo.Transactions", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
