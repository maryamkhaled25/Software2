namespace projecttt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedImageTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "CommentID", "dbo.Comments");
            RenameColumn(table: "dbo.Comments", name: "AccountID", newName: "UserID");
            RenameIndex(table: "dbo.Comments", name: "IX_AccountID", newName: "IX_UserID");
            DropPrimaryKey("dbo.Comments");
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ImageName = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.ImageID)
                .ForeignKey("dbo.Accounts", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Comments", "CommentID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Comments", "ImageID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Comments", "CommentID");
            CreateIndex("dbo.Comments", "ImageID");
            AddForeignKey("dbo.Comments", "ImageID", "dbo.Images", "ImageID", cascadeDelete: true);
            AddForeignKey("dbo.Replies", "CommentID", "dbo.Comments", "CommentID", cascadeDelete: true);
            DropColumn("dbo.Comments", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Replies", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Images", "UserID", "dbo.Accounts");
            DropIndex("dbo.Images", new[] { "UserID" });
            DropIndex("dbo.Comments", new[] { "ImageID" });
            DropPrimaryKey("dbo.Comments");
            DropColumn("dbo.Comments", "ImageID");
            DropColumn("dbo.Comments", "CommentID");
            DropTable("dbo.Images");
            AddPrimaryKey("dbo.Comments", "ID");
            RenameIndex(table: "dbo.Comments", name: "IX_UserID", newName: "IX_AccountID");
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "AccountID");
            AddForeignKey("dbo.Replies", "CommentID", "dbo.Comments", "ID", cascadeDelete: true);
        }
    }
}
