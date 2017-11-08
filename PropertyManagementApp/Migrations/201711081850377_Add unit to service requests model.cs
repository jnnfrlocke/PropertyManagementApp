namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addunittoservicerequestsmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceRequests", "Unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceRequests", "Unit");
        }
    }
}
