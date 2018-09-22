namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolException : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "AdvertiseSalesNotification", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "RememberMe", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "RememberMe", c => c.Boolean());
            AlterColumn("dbo.Customers", "AdvertiseSalesNotification", c => c.Boolean());
        }
    }
}
