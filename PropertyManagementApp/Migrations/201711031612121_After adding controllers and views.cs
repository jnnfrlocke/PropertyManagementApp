namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Afteraddingcontrollersandviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PreferredServiceProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        PreApproved = c.Boolean(nullable: false),
                        Company = c.String(nullable: false),
                        Contact = c.String(),
                        OfficePhone = c.Int(nullable: false),
                        MobilePhone = c.Int(),
                        Email = c.String(),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypesOfServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Landscaping = c.String(),
                        SnowRemoval = c.String(),
                        Pavement = c.String(),
                        Exterior = c.String(),
                        Plumbing = c.String(),
                        Electrical = c.String(),
                        Appliances = c.String(),
                        Painting = c.String(),
                        General = c.String(),
                        HVAC = c.String(),
                        Roofing = c.String(),
                        Windows = c.String(),
                        Cleaning = c.String(),
                        Carpet = c.String(),
                        DrywallInsulation = c.String(),
                        Doors = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypesOfServices");
            DropTable("dbo.PreferredServiceProviders");
        }
    }
}
