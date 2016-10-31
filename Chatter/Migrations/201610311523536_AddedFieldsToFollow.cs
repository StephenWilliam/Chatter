namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldsToFollow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "ChatName_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "ChatName_Id" });
            DropIndex("dbo.Follows", new[] { "User_Id" });
            RenameColumn(table: "dbo.Follows", name: "User_Id", newName: "UserID");
            RenameColumn(table: "dbo.Follows", name: "ApplicationUser_Id", newName: "UserID");
            RenameIndex(table: "dbo.Follows", name: "IX_ApplicationUser_Id", newName: "IX_UserID");
            AddColumn("dbo.Follows", "ChatName", c => c.String());
            DropColumn("dbo.Follows", "ChatName_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Follows", "ChatName_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Follows", "ChatName");
            RenameIndex(table: "dbo.Follows", name: "IX_UserID", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Follows", name: "UserID", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Follows", name: "UserID", newName: "User_Id");
            CreateIndex("dbo.Follows", "User_Id");
            CreateIndex("dbo.Follows", "ChatName_Id");
            AddForeignKey("dbo.Follows", "ChatName_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
