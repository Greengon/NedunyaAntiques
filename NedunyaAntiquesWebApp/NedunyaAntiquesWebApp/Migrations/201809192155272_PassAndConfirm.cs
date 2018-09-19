namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassAndConfirm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ConfirmPassword");
            DropColumn("dbo.Customers", "Password");
        }
    }
}
