namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "HomeNum", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "HomeNum", c => c.Int());
        }
    }
}
