namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FisrtName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            DropColumn("dbo.Customers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "FisrtName");
        }
    }
}
