namespace StudentsFollow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnStudentsFollowsStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentsFollowsStudents", "ImagePatch", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentsFollowsStudents", "ImagePatch");
        }
    }
}
