namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingForeignKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "Title", c => c.Int(nullable: false));
            DropColumn("dbo.Assignments", "Description");
            DropColumn("dbo.Assignments", "OpeningDate");
            DropColumn("dbo.Assignments", "ClosingDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assignments", "ClosingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assignments", "OpeningDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Assignments", "Description", c => c.String());
            AlterColumn("dbo.Assignments", "Title", c => c.String());
        }
    }
}
