namespace Mooshak2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SSN", c => c.String());
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "FullName");
            DropColumn("dbo.AspNetUsers", "SSN");
        }
    }
}
