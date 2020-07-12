namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "PRoID", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "PRoID" });
            RenameColumn(table: "dbo.Orders", name: "PRoID", newName: "prodid");
            AlterColumn("dbo.Orders", "prodid", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "prodid");
            AddForeignKey("dbo.Orders", "prodid", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "prodid", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "prodid" });
            AlterColumn("dbo.Orders", "prodid", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "prodid", newName: "PRoID");
            CreateIndex("dbo.Orders", "PRoID");
            AddForeignKey("dbo.Orders", "PRoID", "dbo.Products", "Id");
        }
    }
}
