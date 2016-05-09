namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAssignmentController : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "Description", c => c.String());
            AddColumn("dbo.Assignments", "OpeningDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assignments", "ClosingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assignments", "SubmissionLimit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "SubmissionLimit");
            DropColumn("dbo.Assignments", "ClosingDate");
            DropColumn("dbo.Assignments", "OpeningDate");
            DropColumn("dbo.Assignments", "Description");
        }
    }
}
