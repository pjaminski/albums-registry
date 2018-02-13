namespace AlbumsRegistry.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminMode : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminModes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordCore = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        ActiveSinceDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminModes");
        }
    }
}
