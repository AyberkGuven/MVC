namespace DbSinav1_9061_Ayberk_Güven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9061Sinav : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        DetailId = c.Int(nullable: false, identity: true),
                        Direction = c.String(),
                        Genders = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetailId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Price = c.String(),
                        Details_DetailId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.Details_DetailId)
                .Index(t => t.Details_DetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Details_DetailId", "dbo.Details");
            DropIndex("dbo.Products", new[] { "Details_DetailId" });
            DropTable("dbo.Products");
            DropTable("dbo.Details");
        }
    }
}
