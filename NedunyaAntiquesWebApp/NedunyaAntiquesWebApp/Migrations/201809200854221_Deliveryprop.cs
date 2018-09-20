namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deliveryprop : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transactions", new[] { "Customer_Email" });
            DropColumn("dbo.Transactions", "CustomerEmail");
            RenameColumn(table: "dbo.Transactions", name: "Customer_Email", newName: "CustomerEmail");
            AddColumn("dbo.Transactions", "Delivery", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Transactions", "CustomerEmail", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "CustomerEmail");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transactions", new[] { "CustomerEmail" });
            AlterColumn("dbo.Transactions", "CustomerEmail", c => c.Int(nullable: false));
            DropColumn("dbo.Transactions", "Delivery");
            RenameColumn(table: "dbo.Transactions", name: "CustomerEmail", newName: "Customer_Email");
            AddColumn("dbo.Transactions", "CustomerEmail", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "Customer_Email");
        }
    }
}
