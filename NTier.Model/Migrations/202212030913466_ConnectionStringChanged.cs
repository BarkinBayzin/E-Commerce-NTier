namespace NTier.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionStringChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Orders_Id", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Orders_Id" });
            DropIndex("dbo.OrderDetails", new[] { "Product_Id" });
            RenameColumn(table: "dbo.OrderDetails", name: "Product_Id", newName: "ProductID");
            RenameColumn(table: "dbo.OrderDetails", name: "Orders_Id", newName: "OrderID");
            AddColumn("dbo.Categories", "CreatedUserName", c => c.String());
            AddColumn("dbo.Categories", "ModifiedUserName", c => c.String());
            AddColumn("dbo.SubCategories", "CreatedUserName", c => c.String());
            AddColumn("dbo.SubCategories", "ModifiedUserName", c => c.String());
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "CreatedUserName", c => c.String());
            AddColumn("dbo.Products", "ModifiedUserName", c => c.String());
            AddColumn("dbo.Orders", "CreatedUserName", c => c.String());
            AddColumn("dbo.Orders", "ModifiedUserName", c => c.String());
            AddColumn("dbo.Users", "CreatedUserName", c => c.String());
            AddColumn("dbo.Users", "ModifiedUserName", c => c.String());
            AddColumn("dbo.OrderDetails", "CreatedUserName", c => c.String());
            AddColumn("dbo.OrderDetails", "ModifiedUserName", c => c.String());
            AlterColumn("dbo.SubCategories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Guid(nullable: false));
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Guid(nullable: false));
            CreateIndex("dbo.OrderDetails", "ProductID");
            CreateIndex("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.Categories", "CreatedADUsername");
            DropColumn("dbo.Categories", "ModifiedADUsername");
            DropColumn("dbo.SubCategories", "CreatedADUsername");
            DropColumn("dbo.SubCategories", "ModifiedADUsername");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "CreatedADUsername");
            DropColumn("dbo.Products", "ModifiedADUsername");
            DropColumn("dbo.Orders", "CreatedADUsername");
            DropColumn("dbo.Orders", "ModifiedADUsername");
            DropColumn("dbo.Users", "CreatedADUsername");
            DropColumn("dbo.Users", "ModifiedADUsername");
            DropColumn("dbo.OrderDetails", "CreatedADUsername");
            DropColumn("dbo.OrderDetails", "ModifiedADUsername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ModifiedADUsername", c => c.String());
            AddColumn("dbo.OrderDetails", "CreatedADUsername", c => c.String());
            AddColumn("dbo.Users", "ModifiedADUsername", c => c.String());
            AddColumn("dbo.Users", "CreatedADUsername", c => c.String());
            AddColumn("dbo.Orders", "ModifiedADUsername", c => c.String());
            AddColumn("dbo.Orders", "CreatedADUsername", c => c.String());
            AddColumn("dbo.Products", "ModifiedADUsername", c => c.String());
            AddColumn("dbo.Products", "CreatedADUsername", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.SubCategories", "ModifiedADUsername", c => c.String());
            AddColumn("dbo.SubCategories", "CreatedADUsername", c => c.String());
            AddColumn("dbo.Categories", "ModifiedADUsername", c => c.String());
            AddColumn("dbo.Categories", "CreatedADUsername", c => c.String());
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            AlterColumn("dbo.OrderDetails", "ProductID", c => c.Guid());
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Guid());
            AlterColumn("dbo.SubCategories", "Name", c => c.String());
            DropColumn("dbo.OrderDetails", "ModifiedUserName");
            DropColumn("dbo.OrderDetails", "CreatedUserName");
            DropColumn("dbo.Users", "ModifiedUserName");
            DropColumn("dbo.Users", "CreatedUserName");
            DropColumn("dbo.Orders", "ModifiedUserName");
            DropColumn("dbo.Orders", "CreatedUserName");
            DropColumn("dbo.Products", "ModifiedUserName");
            DropColumn("dbo.Products", "CreatedUserName");
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.SubCategories", "ModifiedUserName");
            DropColumn("dbo.SubCategories", "CreatedUserName");
            DropColumn("dbo.Categories", "ModifiedUserName");
            DropColumn("dbo.Categories", "CreatedUserName");
            RenameColumn(table: "dbo.OrderDetails", name: "OrderID", newName: "Orders_Id");
            RenameColumn(table: "dbo.OrderDetails", name: "ProductID", newName: "Product_Id");
            CreateIndex("dbo.OrderDetails", "Product_Id");
            CreateIndex("dbo.OrderDetails", "Orders_Id");
            AddForeignKey("dbo.OrderDetails", "Orders_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderDetails", "Product_Id", "dbo.Products", "Id");
        }
    }
}
