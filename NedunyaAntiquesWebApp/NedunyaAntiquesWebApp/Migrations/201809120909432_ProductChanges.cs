namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Images", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Images");
            DropColumn("dbo.Products", "Price");
        }
    }
}
