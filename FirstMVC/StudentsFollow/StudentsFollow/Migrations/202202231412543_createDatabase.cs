namespace StudentsFollow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentsFollowsclassRooms",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentsFollowsStudents",
                c => new
                    {
                        TC = c.String(nullable: false, maxLength: 11),
                        Name = c.String(),
                        Surname = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TC)
                .ForeignKey("dbo.StudentsFollowsclassRooms", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentsFollowsStudents", "Id", "dbo.StudentsFollowsclassRooms");
            DropIndex("dbo.StudentsFollowsStudents", new[] { "Id" });
            DropTable("dbo.StudentsFollowsStudents");
            DropTable("dbo.StudentsFollowsclassRooms");
        }
    }
}
