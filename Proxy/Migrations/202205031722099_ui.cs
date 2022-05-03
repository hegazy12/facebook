namespace Proxy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ui : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "User", c => c.Int(nullable: false));
            DropColumn("dbo.orders", "Ord_User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.orders", "Ord_User", c => c.Int(nullable: false));
            DropColumn("dbo.orders", "User");
        }
    }
}
