namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameOriginalVanue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OriginalVenue", c => c.String());
            AlterColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OriginalValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginalValue", c => c.String());
            AlterColumn("dbo.Notifications", "OriginalDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Notifications", "OriginalVenue");
        }
    }
}
