namespace NedunyaAntiquesWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _NewDBWithOutCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProductId" });
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingCartId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ShoppingCartId);
            
            AddColumn("dbo.Products", "CartId", c => c.String());
            AddColumn("dbo.Products", "inCart", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "sold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "Paid", c => c.Boolean(nullable: false));
            AddColumn("dbo.Transactions", "Cart_ShoppingCartId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Transactions", "Cart_ShoppingCartId");
            AddForeignKey("dbo.Transactions", "Cart_ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId");
            DropTable("dbo.Carts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Transactions", "Cart_ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.Transactions", new[] { "Cart_ShoppingCartId" });
            DropColumn("dbo.Transactions", "Cart_ShoppingCartId");
            DropColumn("dbo.Transactions", "Paid");
            DropColumn("dbo.Products", "sold");
            DropColumn("dbo.Products", "inCart");
            DropColumn("dbo.Products", "CartId");
            DropTable("dbo.ShoppingCarts");
            CreateIndex("dbo.Carts", "ProductId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
