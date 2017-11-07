namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resetdatesubmittedtooriginalinservicerequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "DateSubmitted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "DateSubmitted");
        }
    }
}
