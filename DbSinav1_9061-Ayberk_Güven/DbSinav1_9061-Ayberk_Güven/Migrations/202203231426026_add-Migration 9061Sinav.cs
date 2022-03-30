namespace DbSinav1_9061_Ayberk_Güven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMigration9061Sinav : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Direction", c => c.String());
            DropColumn("dbo.Details", "Direction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Details", "Direction", c => c.String());
            DropColumn("dbo.Products", "Direction");
        }
    }
}
