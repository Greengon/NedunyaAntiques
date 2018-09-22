namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullBool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "AdvertiseSalesNotification", c => c.Boolean());
            AlterColumn("dbo.Customers", "RememberMe", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "RememberMe", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Customers", "AdvertiseSalesNotification", c => c.Boolean(nullable: false));
        }
    }
}
