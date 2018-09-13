namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdvertiseNot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AdvertiseSalesNotification", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "AdvertiseSalesNotification");
        }
    }
}
