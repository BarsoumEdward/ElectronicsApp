namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class step4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPrice");
        }
    }
}
