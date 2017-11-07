namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setdatetotodayinservicerequests : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceRequests", "DateSubmitted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceRequests", "DateSubmitted", c => c.DateTime(nullable: false));
        }
    }
}
