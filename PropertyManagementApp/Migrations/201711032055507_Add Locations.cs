namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
        }
    }
}
