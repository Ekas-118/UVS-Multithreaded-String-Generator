namespace DesktopUI.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTimeTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Data", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Data", "Time", c => c.DateTime(nullable: false));
        }
    }
}
