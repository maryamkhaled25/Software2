namespace Instagram_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedImageTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "UserID", "dbo.Accounts");
            DropIndex("dbo.Images", new[] { "UserID" });
            DropTable("dbo.Images");
        }
    }
}
