namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionInMilestone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignmentMilestones", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssignmentMilestones", "Description");
        }
    }
}
