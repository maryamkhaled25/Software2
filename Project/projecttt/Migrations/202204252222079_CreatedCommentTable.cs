namespace projecttt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedCommentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        CommentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .Index(t => t.CommentID);
            
            AlterColumn("dbo.Accounts", "FName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Accounts", "LName", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Accounts", "Mobile", c => c.String(nullable: false, maxLength: 11, unicode: false));
            AlterColumn("dbo.Accounts", "Email", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            CreateIndex("dbo.Accounts", "FName", unique: true);
            CreateIndex("dbo.Accounts", "LName", unique: true);
            CreateIndex("dbo.Accounts", "Mobile", unique: true);
            CreateIndex("dbo.Accounts", "Email", unique: true);

            DropPrimaryKey("dbo.Comments", new[] { "AccountId" });
            DropColumn("dbo.Comments", "AccountId");
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Replies", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Replies", new[] { "CommentID" });
            DropIndex("dbo.Comments", new[] { "AccountID" });
            DropIndex("dbo.Accounts", new[] { "Email" });
            DropIndex("dbo.Accounts", new[] { "Mobile" });
            DropIndex("dbo.Accounts", new[] { "LName" });
            DropIndex("dbo.Accounts", new[] { "FName" });
            AlterColumn("dbo.Accounts", "Email", c => c.String());
            AlterColumn("dbo.Accounts", "Mobile", c => c.String());
            AlterColumn("dbo.Accounts", "LName", c => c.String());
            AlterColumn("dbo.Accounts", "FName", c => c.String());
            DropTable("dbo.Replies");
            DropTable("dbo.Comments");
        }
    }
}
