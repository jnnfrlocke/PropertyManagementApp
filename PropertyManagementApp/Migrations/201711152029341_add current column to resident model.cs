namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcurrentcolumntoresidentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residents", "Current", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Residents", "Current");
        }
    }
}
