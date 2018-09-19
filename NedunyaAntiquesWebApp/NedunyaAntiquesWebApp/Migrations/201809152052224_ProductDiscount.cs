namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PriceAfterDiscount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PriceAfterDiscount");
        }
    }
}
