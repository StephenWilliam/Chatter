namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedFollow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "ChatName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "ChatName_Id" });
            DropIndex("dbo.Follows", new[] { "User_Id" });
            AddColumn("dbo.Follows", "ChatName", c => c.String());
            DropColumn("dbo.Follows", "ChatName_Id");
            DropColumn("dbo.Follows", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Follows", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Follows", "ChatName_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Follows", "ChatName");
            CreateIndex("dbo.Follows", "User_Id");
            CreateIndex("dbo.Follows", "ChatName_Id");
            AddForeignKey("dbo.Follows", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Follows", "ChatName_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
