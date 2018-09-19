namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "username", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "password", c => c.String());
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
           
            DropColumn("dbo.Customers", "IsSubscribed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribed", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "FisrtName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "ConfirmPassword");
            DropColumn("dbo.Customers", "password");
            DropColumn("dbo.Customers", "username");
        }
    }
}
