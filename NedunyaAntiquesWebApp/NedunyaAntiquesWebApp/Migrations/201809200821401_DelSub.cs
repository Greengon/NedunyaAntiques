namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelSub : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsSubscribed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribed", c => c.Boolean(nullable: false));
        }
    }
}
