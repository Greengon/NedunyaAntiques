namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullyUpgradedCust : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CityAddress", c => c.String());
            AddColumn("dbo.Customers", "StreetAddress", c => c.String());
            AddColumn("dbo.Customers", "HomeNum", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "AptNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AptNum");
            DropColumn("dbo.Customers", "HomeNum");
            DropColumn("dbo.Customers", "StreetAddress");
            DropColumn("dbo.Customers", "CityAddress");
        }
    }
}
