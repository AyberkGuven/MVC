namespace Shop1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NewProduct", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "New");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "New", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "NewProduct");
        }
    }
}
