namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentedProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Rented", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Rented");
        }
    }
}
