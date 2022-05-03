namespace Proxy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class o7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "Ord_User", c => c.Int(nullable: false));
            DropColumn("dbo.orders", "ord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.orders", "ord", c => c.Int(nullable: false));
            DropColumn("dbo.orders", "Ord_User");
        }
    }
}
