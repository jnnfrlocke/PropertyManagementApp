namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedDateCompletedinservicerequests : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceRequests", "DateCompleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceRequests", "DateCompleted", c => c.DateTime(nullable: false));
        }
    }
}
