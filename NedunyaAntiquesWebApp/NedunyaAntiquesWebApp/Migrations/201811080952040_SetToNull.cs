namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetToNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "HomeNum", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
            AlterColumn("dbo.AspNetUsers", "HomeNum", c => c.Int(nullable: false));
        }
    }
}
