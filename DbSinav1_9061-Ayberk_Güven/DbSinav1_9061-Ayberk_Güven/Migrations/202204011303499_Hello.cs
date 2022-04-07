namespace DbSinav1_9061_Ayberk_Güven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hello : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genders = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Direction = c.String(),
                        DetailsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Details", t => t.DetailsId, cascadeDelete: true)
                .Index(t => t.DetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "DetailsId", "dbo.Details");
            DropIndex("dbo.Products", new[] { "DetailsId" });
            DropTable("dbo.Products");
            DropTable("dbo.Details");
        }
    }
}
