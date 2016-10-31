namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFollowClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowID = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ChatName_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FollowID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ChatName_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.ChatName_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "ChatName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "User_Id" });
            DropIndex("dbo.Follows", new[] { "ChatName_Id" });
            DropIndex("dbo.Follows", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Follows");
        }
    }
}
