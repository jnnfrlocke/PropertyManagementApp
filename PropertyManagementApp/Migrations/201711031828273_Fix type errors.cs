namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixtypeerrors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        TypeOfService = c.String(),
                        Details = c.String(),
                        Urgency = c.String(),
                        DateSubmitted = c.DateTime(nullable: false),
                        ContractorUsed = c.String(),
                        FollowUpNeeded = c.Boolean(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        DateCompleted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.PreferredServiceProviders", "OfficePhone", c => c.String(nullable: false));
            AlterColumn("dbo.PreferredServiceProviders", "MobilePhone", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PreferredServiceProviders", "MobilePhone", c => c.Int());
            AlterColumn("dbo.PreferredServiceProviders", "OfficePhone", c => c.Int(nullable: false));
            DropTable("dbo.ServiceRequests");
        }
    }
}
