namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Height", c => c.Double());
            AlterColumn("dbo.Products", "Width", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Width", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Height", c => c.Double(nullable: false));
        }
    }
}
