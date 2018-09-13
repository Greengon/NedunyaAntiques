namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PhoneNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PhoneNum");
        }
    }
}
