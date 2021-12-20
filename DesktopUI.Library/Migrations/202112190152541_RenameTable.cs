namespace DesktopUI.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GeneratedDataModels", newName: "Data");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Data", newName: "GeneratedDataModels");
        }
    }
}
