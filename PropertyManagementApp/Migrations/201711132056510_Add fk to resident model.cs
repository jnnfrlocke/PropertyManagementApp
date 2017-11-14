namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addfktoresidentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Residents", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Residents", "User_Id");
            AddForeignKey("dbo.Residents", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Residents", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Residents", new[] { "User_Id" });
            DropColumn("dbo.Residents", "User_Id");
        }
    }
}
