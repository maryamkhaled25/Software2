namespace Instagram_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedCommnetTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "UserID", "dbo.Accounts");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        UserID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Accounts", t => t.UserID)
                .ForeignKey("dbo.Images", t => t.ImageID)
                .Index(t => t.UserID)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Comment_CommentID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.Comment_CommentID)
                .Index(t => t.Comment_CommentID);
            
            AddForeignKey("dbo.Images", "UserID", "dbo.Accounts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "UserID", "dbo.Accounts");
            DropForeignKey("dbo.Replies", "Comment_CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Accounts");
            DropIndex("dbo.Replies", new[] { "Comment_CommentID" });
            DropIndex("dbo.Comments", new[] { "ImageID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropTable("dbo.Replies");
            DropTable("dbo.Comments");
            AddForeignKey("dbo.Images", "UserID", "dbo.Accounts", "ID", cascadeDelete: true);
        }
    }
}
