namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionToDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "AptNum", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "AptNum", c => c.Int(nullable: false));
        }
    }
}
