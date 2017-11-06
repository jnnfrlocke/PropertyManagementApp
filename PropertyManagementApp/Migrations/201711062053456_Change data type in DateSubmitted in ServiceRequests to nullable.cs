namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedatatypeinDateSubmittedinServiceRequeststonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ServiceRequests", "DateSubmitted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ServiceRequests", "DateSubmitted", c => c.DateTime(nullable: false));
        }
    }
}
