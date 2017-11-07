namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedatesubmittedtostringinservicerequests : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceRequests", "DateSubmitted", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceRequests", "DateSubmitted", c => c.DateTime(nullable: false));
        }
    }
}
