namespace Shop1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopDbs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImagePath = c.String(),
                        CategoryId = c.Byte(nullable: false),
                        MarkId = c.Byte(nullable: false),
                        New = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Marks", t => t.MarkId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.MarkId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "MarkId", "dbo.Marks");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "MarkId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Marks");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
