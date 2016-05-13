namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSolutionEntity2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Solutions", "correctness", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Solutions", "correctness");
        }
    }
}
