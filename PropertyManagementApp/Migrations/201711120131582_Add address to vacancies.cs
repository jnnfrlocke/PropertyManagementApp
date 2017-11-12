namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addaddresstovacancies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacancies", "StreetNumber", c => c.String());
            AddColumn("dbo.Vacancies", "StreetName", c => c.String());
            AddColumn("dbo.Vacancies", "City", c => c.String());
            AddColumn("dbo.Vacancies", "State", c => c.String());
            AddColumn("dbo.Vacancies", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vacancies", "ZipCode");
            DropColumn("dbo.Vacancies", "State");
            DropColumn("dbo.Vacancies", "City");
            DropColumn("dbo.Vacancies", "StreetName");
            DropColumn("dbo.Vacancies", "StreetNumber");
        }
    }
}
