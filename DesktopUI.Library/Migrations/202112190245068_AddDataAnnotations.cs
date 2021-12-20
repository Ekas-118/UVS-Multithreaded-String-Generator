namespace DesktopUI.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data", "ThreadId", c => c.String(nullable: false));
            AlterColumn("dbo.Data", "Data", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Data", "Data", c => c.String());
            AlterColumn("dbo.Data", "ThreadId", c => c.String());
        }
    }
}
