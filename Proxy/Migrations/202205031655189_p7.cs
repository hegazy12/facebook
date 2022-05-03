namespace Proxy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class p7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ord = c.Int(nullable: false),
                        item_id = c.Int(nullable: false),
                        itemfood_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.itemfoods", t => t.itemfood_id)
                .Index(t => t.itemfood_id);
            
            DropTable("dbo.Addtions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addtions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        photo = c.String(),
                        Description = c.String(),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.orders", "itemfood_id", "dbo.itemfoods");
            DropIndex("dbo.orders", new[] { "itemfood_id" });
            DropTable("dbo.orders");
        }
    }
}
