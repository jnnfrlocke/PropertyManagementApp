namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class justkiddingreallyaddavailableUnitninforequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableUnitInfoRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AvailableUnitInfoRequests");
        }
    }
}
