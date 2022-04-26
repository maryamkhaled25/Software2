namespace projecttt.Migrations
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
                        FName = c.String(),
                        LName = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        ProfileImage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Accounts");
        }
    }
}
