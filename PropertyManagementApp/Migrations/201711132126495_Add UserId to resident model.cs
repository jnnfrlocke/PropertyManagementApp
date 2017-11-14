namespace PropertyManagementApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdtoresidentmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Residents", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Residents", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Residents", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Residents", name: "UserId", newName: "User_Id");
        }
    }
}
