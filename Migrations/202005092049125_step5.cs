namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}
