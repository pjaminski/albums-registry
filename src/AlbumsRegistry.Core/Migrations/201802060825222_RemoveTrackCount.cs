namespace AlbumsRegistry.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTrackCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Albums", "TracksCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "TracksCount", c => c.Int());
        }
    }
}
