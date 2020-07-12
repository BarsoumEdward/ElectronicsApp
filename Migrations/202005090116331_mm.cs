namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.OrderProducts", new[] { "Order_Id" });
            DropIndex("dbo.OrderProducts", new[] { "Product_Id" });
            AddColumn("dbo.Orders", "PRoID", c => c.Int());
            CreateIndex("dbo.Orders", "PRoID");
            AddForeignKey("dbo.Orders", "PRoID", "dbo.Products", "Id");
            DropTable("dbo.OrderProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Product_Id });
            
            DropForeignKey("dbo.Orders", "PRoID", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "PRoID" });
            DropColumn("dbo.Orders", "PRoID");
            CreateIndex("dbo.OrderProducts", "Product_Id");
            CreateIndex("dbo.OrderProducts", "Order_Id");
            AddForeignKey("dbo.OrderProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderProducts", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
