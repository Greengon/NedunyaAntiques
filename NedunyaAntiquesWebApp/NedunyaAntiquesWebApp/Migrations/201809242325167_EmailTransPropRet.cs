namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailTransPropRet : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Transactions", name: "Customer_Email", newName: "CustomerEmail");
            RenameIndex(table: "dbo.Transactions", name: "IX_Customer_Email", newName: "IX_CustomerEmail");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Transactions", name: "IX_CustomerEmail", newName: "IX_Customer_Email");
            RenameColumn(table: "dbo.Transactions", name: "CustomerEmail", newName: "Customer_Email");
        }
    }
}
