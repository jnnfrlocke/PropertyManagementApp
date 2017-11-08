namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrentandpaymenttoresidentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residents", "Rent", c => c.Int(nullable: false));
            AddColumn("dbo.Residents", "Payment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Residents", "Payment");
            DropColumn("dbo.Residents", "Rent");
        }
    }
}
