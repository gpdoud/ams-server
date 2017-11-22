namespace AssetManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class core : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vendor = c.String(),
                        Name = c.String(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseOrderNumber = c.String(),
                        AssetCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OutForRepairDate = c.DateTime(nullable: false),
                        BackFromRepairDate = c.DateTime(nullable: false),
                        RetiredDate = c.DateTime(nullable: false),
                        SurplusDate = c.DateTime(nullable: false),
                        SaleProceeds = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Photopath = c.String(),
                        Type = c.String(),
                        LocationId = c.Int(nullable: false),
                        AssignedTo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Department = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        AssetId = c.Int(nullable: false),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        VIN = c.String(nullable: false),
                        License = c.String(nullable: false),
                        HasLights = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssetId)
                .ForeignKey("dbo.Assets", t => t.AssetId)
                .Index(t => t.AssetId);
            
            CreateTable(
                "dbo.ServiceRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        AdminLevel = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.Assets", "LocationId", "dbo.Locations");
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Vehicles", new[] { "AssetId" });
            DropIndex("dbo.Assets", new[] { "LocationId" });
            DropTable("dbo.Users");
            DropTable("dbo.ServiceRecords");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Locations");
            DropTable("dbo.Assets");
        }
    }
}
