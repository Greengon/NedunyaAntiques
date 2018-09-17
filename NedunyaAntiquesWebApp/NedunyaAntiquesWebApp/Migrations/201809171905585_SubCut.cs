namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubCut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Subcategory", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "ConfirmPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "PriceAfterDiscount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PriceAfterDiscount", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "ConfirmPassword", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            DropColumn("dbo.Products", "Subcategory");
        }
    }
}
