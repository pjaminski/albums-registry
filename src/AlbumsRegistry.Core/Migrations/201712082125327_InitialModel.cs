namespace AlbumsRegistry.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        ReleaseYear = c.Int(),
                        TracksCount = c.Int(),
                        Artist_Id = c.Int(nullable: false),
                        Publisher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.Publisher_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        City = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        City = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Publisher_Id", "dbo.Publishers");
            DropForeignKey("dbo.Albums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Albums", new[] { "Publisher_Id" });
            DropIndex("dbo.Albums", new[] { "Artist_Id" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
        }
    }
}
