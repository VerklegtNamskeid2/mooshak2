namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryingForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Assignments", "CoursesID");
            AddForeignKey("dbo.Assignments", "CoursesID", "dbo.Courses", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "CoursesID", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "CoursesID" });
        }
    }
}
