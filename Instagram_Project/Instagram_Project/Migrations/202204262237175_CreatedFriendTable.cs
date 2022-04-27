namespace Instagram_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedFriendTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendsID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FriendsID)
                .ForeignKey("dbo.Accounts", t => t.UserID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "UserID", "dbo.Accounts");
            DropIndex("dbo.Friends", new[] { "UserID" });
            DropTable("dbo.Friends");
        }
    }
}
