namespace Instagram_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAccountTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        LName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Mobile = c.String(nullable: false, maxLength: 11, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ProfileImage = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.FName, unique: true)
                .Index(t => t.LName, unique: true)
                .Index(t => t.Mobile, unique: true)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Accounts", new[] { "Email" });
            DropIndex("dbo.Accounts", new[] { "Mobile" });
            DropIndex("dbo.Accounts", new[] { "LName" });
            DropIndex("dbo.Accounts", new[] { "FName" });
            DropTable("dbo.Accounts");
        }
    }
}
