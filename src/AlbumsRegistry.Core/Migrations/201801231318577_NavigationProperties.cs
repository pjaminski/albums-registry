namespace AlbumsRegistry.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NavigationProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "Publisher_Id", "dbo.Publishers");
            DropIndex("dbo.Albums", new[] { "Publisher_Id" });
            RenameColumn(table: "dbo.Albums", name: "Artist_Id", newName: "ArtistId");
            RenameColumn(table: "dbo.Albums", name: "Publisher_Id", newName: "PublisherId");
            RenameIndex(table: "dbo.Albums", name: "IX_Artist_Id", newName: "IX_ArtistId");
            AlterColumn("dbo.Albums", "PublisherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Artists", "Name", c => c.String());
            AlterColumn("dbo.Artists", "City", c => c.String());
            AlterColumn("dbo.Publishers", "Name", c => c.String());
            AlterColumn("dbo.Publishers", "City", c => c.String());
            CreateIndex("dbo.Albums", "PublisherId");
            AddForeignKey("dbo.Albums", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "PublisherId", "dbo.Publishers");
            DropIndex("dbo.Albums", new[] { "PublisherId" });
            AlterColumn("dbo.Publishers", "City", c => c.String(maxLength: 255));
            AlterColumn("dbo.Publishers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Artists", "City", c => c.String(maxLength: 255));
            AlterColumn("dbo.Artists", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Albums", "PublisherId", c => c.Int());
            RenameIndex(table: "dbo.Albums", name: "IX_ArtistId", newName: "IX_Artist_Id");
            RenameColumn(table: "dbo.Albums", name: "PublisherId", newName: "Publisher_Id");
            RenameColumn(table: "dbo.Albums", name: "ArtistId", newName: "Artist_Id");
            CreateIndex("dbo.Albums", "Publisher_Id");
            AddForeignKey("dbo.Albums", "Publisher_Id", "dbo.Publishers", "Id");
        }
    }
}
