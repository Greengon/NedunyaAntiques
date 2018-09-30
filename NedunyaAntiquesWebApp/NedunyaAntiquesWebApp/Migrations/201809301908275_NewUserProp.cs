namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewUserProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "NewPassword", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Customers", "ConfirmNewPassword", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "ConfirmNewPassword");
            DropColumn("dbo.Customers", "NewPassword");
        }
    }
}
