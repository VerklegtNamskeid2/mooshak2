namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignments", "CoursesID", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "CoursesID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Assignments", "CoursesID");
            AddForeignKey("dbo.Assignments", "CoursesID", "dbo.Courses", "ID", cascadeDelete: true);
        }
    }
}
