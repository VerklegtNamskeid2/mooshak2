namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleFromIntToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Title", c => c.String());
            AlterColumn("dbo.Assignments", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assignments", "Title", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Title");
        }
    }
}
