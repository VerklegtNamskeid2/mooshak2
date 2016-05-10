namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTitleToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "Title", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assignments", "Title", c => c.String());
        }
    }
}
