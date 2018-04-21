namespace AssetManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addlog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Application = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Method = c.String(nullable: false),
                        Level = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
