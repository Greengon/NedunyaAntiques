namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalPropNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "RentalPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "RentalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
