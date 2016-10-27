namespace Chatter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserID : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        MessageContent = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropTable("dbo.Messages");
        }
    }
}
