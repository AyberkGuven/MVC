namespace StudentsFollow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentFollowDb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 11),
                        Name = c.String(),
                        Surname = c.String(),
                        Gender = c.Boolean(nullable: false),
                        ImagePatch = c.String(),
                        ClassroomId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classrooms", t => t.ClassroomId, cascadeDelete: true)
                .Index(t => t.ClassroomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassroomId", "dbo.Classrooms");
            DropIndex("dbo.Students", new[] { "ClassroomId" });
            DropTable("dbo.Students");
            DropTable("dbo.Classrooms");
        }
    }
}
