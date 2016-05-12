namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersCourses", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Solutions", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Solutions", "MilestoneID", "dbo.AssignmentMilestones");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Assignments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.MilestoneInputOutputs", "MilestoneID", "dbo.AssignmentMilestones");
            DropForeignKey("dbo.AssignmentMilestones", "AssignmentID", "dbo.Assignments");
            DropIndex("dbo.UsersCourses", new[] { "CourseID" });
            DropIndex("dbo.UsersCourses", new[] { "UserID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Solutions", new[] { "MilestoneID" });
            DropIndex("dbo.Solutions", new[] { "UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.MilestoneInputOutputs", new[] { "MilestoneID" });
            DropIndex("dbo.AssignmentMilestones", new[] { "AssignmentID" });
            DropIndex("dbo.Assignments", new[] { "CourseID" });
            DropTable("dbo.UsersCourses");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Solutions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Courses");
            DropTable("dbo.MilestoneInputOutputs");
            DropTable("dbo.AssignmentMilestones");
            DropTable("dbo.Assignments");
        }
    }
}
