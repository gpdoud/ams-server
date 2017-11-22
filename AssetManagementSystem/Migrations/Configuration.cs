namespace AssetManagementSystem.Migrations
{
    using AssetManagementSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AssetManagementSystem.Models.AssetManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AssetManagementSystem.Models.AssetManagementSystemContext";
        }

        protected override void Seed(AssetManagementSystem.Models.AssetManagementSystemContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Locations.AddOrUpdate(
                l => l.Name,
                new Location { Name = "loc1", Department = "dep1", Address = "add1", City = "City", State = "ST", Phone = "phone" },
                new Location { Name = "loc2", Department = "dep2", Address = "add2", City = "City", State = "ST", Phone = "phone" },
                new Location { Name = "loc3", Department = "dep3", Address = "add3", City = "City", State = "ST", Phone = "phone" }
                );

            context.Users.AddOrUpdate(
                u => u.Username,
                new User { Username = "user1", Password = "pw1", FirstName = "fn1", LastName = "ln1", Email = "email1", AdminLevel = 2, IsActive = true },
                new User { Username = "user2", Password = "pw2", FirstName = "fn2", LastName = "ln2", Email = "email2", AdminLevel = 1, IsActive = true },
                new User { Username = "user3", Password = "pw3", FirstName = "fn3", LastName = "ln3", Email = "email3", AdminLevel = 0, IsActive = true }
            );
            context.SaveChanges();

            context.Assets.AddOrUpdate(
                a => a.Name,
                new Asset {
                    Name = "asset1",
                    Photopath = "",
                    AssetCost = 9.99M,
                    AssignedTo = "Bob Jones",
                    Vendor = "bob",
                    LocationId = context.Locations.SingleOrDefault(l => l.Name == "loc1").Id,
                    Location = context.Locations.SingleOrDefault(l => l.Name == "loc1"),
                    PurchaseDate = DateTime.Now,
                    PurchaseOrderNumber = "7b",
                    OutForRepairDate = DateTime.Now,
                    BackFromRepairDate = DateTime.Now.AddDays(4),
                    RetiredDate = DateTime.Now,
                    SurplusDate = DateTime.Now.AddMonths(2),
                    SaleProceeds = 27000M,
                    Type = "Vehicle"
                },
                new Asset
                {
                    Name = "asset2",
                    Photopath = "",
                    AssetCost = 29.99M,
                    AssignedTo = "Bob Jones",
                    Vendor = "bob",
                    LocationId = context.Locations.SingleOrDefault(l => l.Name == "loc2").Id,
                    Location = context.Locations.SingleOrDefault(l => l.Name == "loc2"),
                    PurchaseDate = DateTime.Now,
                    PurchaseOrderNumber = "27b",
                    OutForRepairDate = DateTime.Now,
                    BackFromRepairDate = DateTime.Now.AddDays(4),
                    RetiredDate = DateTime.Now,
                    SurplusDate = DateTime.Now.AddMonths(2),
                    SaleProceeds = 27000M,
                    Type = "Vehicle"
                },
                new Asset
                {
                    Name = "asset3",
                    Photopath = "",
                    AssetCost = 39.99M,
                    AssignedTo = "Hungry Jack",
                    Vendor = "Bob Evans",
                    LocationId = context.Locations.SingleOrDefault(l => l.Name == "loc3").Id,
                    Location = context.Locations.SingleOrDefault(l => l.Name == "loc3"),
                    PurchaseDate = DateTime.Now,
                    PurchaseOrderNumber = "37b",
                    OutForRepairDate = DateTime.Now,
                    BackFromRepairDate = DateTime.Now.AddDays(4),
                    RetiredDate = DateTime.Now,
                    SurplusDate = DateTime.Now.AddMonths(2),
                    SaleProceeds = 27000000M,
                    Type = "Sandwich"
                },
                new Asset
                {
                    Name = "asset4",
                    Photopath = "",
                    AssetCost = 9.99M,
                    AssignedTo = "Bob Jones",
                    Vendor = "bob",
                    LocationId = context.Locations.SingleOrDefault(l => l.Name == "loc1").Id,
                    Location = context.Locations.SingleOrDefault(l => l.Name == "loc1"),
                    PurchaseDate = DateTime.Now,
                    PurchaseOrderNumber = "7b",
                    OutForRepairDate = DateTime.Now,
                    BackFromRepairDate = DateTime.Now.AddDays(4),
                    RetiredDate = DateTime.Now,
                    SurplusDate = DateTime.Now.AddMonths(2),
                    SaleProceeds = 27000M,
                    Type = "Vehicle"
                }
            );
            context.SaveChanges();

            context.Vehicles.AddOrUpdate(
                v => v.VIN,
                new Vehicle {
                    AssetId = context.Assets.SingleOrDefault(a => a.Name == "asset1").Id,
                    Asset = context.Assets.SingleOrDefault(a => a.Name == "asset1"),
                    VIN = "VIN1",
                    Make = "Make1",
                    Model = "Model1",
                    License = "DFTWP1",
                    HasLights = false
                },
                new Vehicle {
                    AssetId = context.Assets.SingleOrDefault(a => a.Name == "asset2").Id,
                    Asset = context.Assets.SingleOrDefault(a => a.Name == "asset2"),
                    VIN = "VIN2",
                    Make = "Make2",
                    Model = "Model2",
                    License = "DFTWP2",
                    HasLights = true
                },
                new Vehicle {
                    AssetId = context.Assets.SingleOrDefault(a => a.Name == "asset4").Id,
                    Asset = context.Assets.SingleOrDefault(a => a.Name == "asset4"),
                    VIN = "VIN4",
                    Make = "Make4",
                    Model = "Model4",
                    License = "DFTWP3",
                    HasLights = false
                }
            );
        }
    }
}
