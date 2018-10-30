namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTransaction : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Transactions", new[] { "Customer_Id" });
            CreateIndex("dbo.Transactions", "customer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transactions", new[] { "customer_Id" });
            CreateIndex("dbo.Transactions", "Customer_Id");
        }
    }
}
