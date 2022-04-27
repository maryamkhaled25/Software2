namespace Instagram_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdReactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reacts",
                c => new
                    {
                        ReactID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        ImageID = c.Int(nullable: false),
                        NumberOfLikes = c.Long(nullable: false),
                        NumberOfDisLikes = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ReactID)
                .ForeignKey("dbo.Accounts", t => t.UserID)
                .ForeignKey("dbo.Images", t => t.ImageID)
                .Index(t => t.UserID)
                .Index(t => t.ImageID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reacts", "ImageID", "dbo.Images");
            DropForeignKey("dbo.Reacts", "UserID", "dbo.Accounts");
            DropIndex("dbo.Reacts", new[] { "ImageID" });
            DropIndex("dbo.Reacts", new[] { "UserID" });
            DropTable("dbo.Reacts");
        }
    }
}
