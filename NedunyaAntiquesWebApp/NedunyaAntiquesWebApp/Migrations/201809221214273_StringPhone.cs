namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringPhone : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PhoneNum", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PhoneNum", c => c.Int(nullable: false));
        }
    }
}
