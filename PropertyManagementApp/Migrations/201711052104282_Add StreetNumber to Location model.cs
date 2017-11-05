namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStreetNumbertoLocationmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "StreetNumber", c => c.String());
            AddColumn("dbo.Locations", "StreetName", c => c.String());
            DropColumn("dbo.Locations", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "Address", c => c.String());
            DropColumn("dbo.Locations", "StreetName");
            DropColumn("dbo.Locations", "StreetNumber");
        }
    }
}
