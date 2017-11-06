namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getuptodate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residents", "Name", c => c.String());
            AddColumn("dbo.Residents", "Location", c => c.String());
            AddColumn("dbo.Residents", "Unit", c => c.String());
            AddColumn("dbo.Residents", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Residents", "EmailAddress");
            DropColumn("dbo.Residents", "Unit");
            DropColumn("dbo.Residents", "Location");
            DropColumn("dbo.Residents", "Name");
        }
    }
}
