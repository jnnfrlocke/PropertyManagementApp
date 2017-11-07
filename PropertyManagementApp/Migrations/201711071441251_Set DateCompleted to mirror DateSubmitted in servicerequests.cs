namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDateCompletedtomirrorDateSubmittedinservicerequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "DateCompleted", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "DateCompleted");
        }
    }
}
