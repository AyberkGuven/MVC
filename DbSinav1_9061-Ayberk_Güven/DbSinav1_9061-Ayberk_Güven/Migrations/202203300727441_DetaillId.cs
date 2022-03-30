namespace DbSinav1_9061_Ayberk_Güven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DetaillId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DetailsId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "DetailsId");
        }
    }
}
