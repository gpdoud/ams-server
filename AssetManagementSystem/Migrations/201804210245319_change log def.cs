namespace AssetManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changelogdef : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "LogLevel", c => c.String(nullable: false));
            AlterColumn("dbo.Logs", "Application", c => c.String());
            AlterColumn("dbo.Logs", "Class", c => c.String());
            AlterColumn("dbo.Logs", "Method", c => c.String());
            DropColumn("dbo.Logs", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "Level", c => c.String(nullable: false));
            AlterColumn("dbo.Logs", "Method", c => c.String(nullable: false));
            AlterColumn("dbo.Logs", "Class", c => c.String(nullable: false));
            AlterColumn("dbo.Logs", "Application", c => c.String(nullable: false));
            DropColumn("dbo.Logs", "LogLevel");
        }
    }
}
