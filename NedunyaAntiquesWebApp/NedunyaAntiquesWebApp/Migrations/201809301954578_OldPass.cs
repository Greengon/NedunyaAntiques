namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OldPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "OldPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OldPassword");
        }
    }
}
