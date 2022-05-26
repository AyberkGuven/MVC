namespace _2.Dönem_2.Sinav_Ayberk_Güven_9061.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class openss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropIndex("dbo.Products", new[] { "ImageId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Products", "ImageId");
            AddForeignKey("dbo.Products", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
    }
}
