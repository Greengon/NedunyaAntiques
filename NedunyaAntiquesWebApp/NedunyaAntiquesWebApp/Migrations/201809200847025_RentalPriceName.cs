namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalPriceName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "RentalPriceForDay", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Products", "RentalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "RentalPrice", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Products", "RentalPriceForDay");
        }
    }
}
