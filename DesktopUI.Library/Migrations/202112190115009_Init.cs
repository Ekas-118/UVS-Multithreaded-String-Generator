namespace DesktopUI.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneratedDataModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThreadId = c.String(),
                        Time = c.DateTime(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneratedDataModels");
        }
    }
}
