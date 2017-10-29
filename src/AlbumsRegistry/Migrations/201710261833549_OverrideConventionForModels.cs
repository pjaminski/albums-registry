namespace AlbumsRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionForModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            AlterColumn("dbo.Albums", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Albums", "Artist_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Artists", "City", c => c.String(maxLength: 255));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Publishers", "City", c => c.String(maxLength: 255));
            CreateIndex("dbo.Albums", "Artist_Id");
            AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            AlterColumn("dbo.Publishers", "City", c => c.String());
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Artists", "City", c => c.String());
            AlterColumn("dbo.Artists", "Name", c => c.String());
            AlterColumn("dbo.Albums", "Artist_Id", c => c.Int());
            AlterColumn("dbo.Albums", "Title", c => c.String());
            CreateIndex("dbo.Albums", "Artist_Id");
            AddForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists", "Id");
        }
    }
}
