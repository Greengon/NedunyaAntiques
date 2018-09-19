namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoginInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "LastLoginDate", c => c.DateTime());
            AddColumn("dbo.Customers", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "RememberMe");
            DropColumn("dbo.Customers", "LastLoginDate");
            DropColumn("dbo.Customers", "CreatedDate");
        }
    }
}
