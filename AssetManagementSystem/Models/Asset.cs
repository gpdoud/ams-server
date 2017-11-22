using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class Asset
    {
        [Required]
        public int Id { get; set; }

        public string Vendor { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string PurchaseOrderNumber { get; set; }

        [Required]
        public decimal AssetCost { get; set; }

        public DateTime OutForRepairDate { get; set; }

        public DateTime BackFromRepairDate { get; set; }

        public DateTime RetiredDate { get; set; }

        public DateTime SurplusDate { get; set; }

        public decimal SaleProceeds { get; set; }

        public string Photopath { get; set; }

        public string Type { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public string AssignedTo { get; set; }

        public void Copy(Asset asset)
        {
            if (asset == null)
                return;

            Id = asset.Id;
            Vendor = asset.Vendor;
            Name = asset.Name;
            PurchaseDate = asset.PurchaseDate;
            PurchaseOrderNumber = asset.PurchaseOrderNumber;
            AssetCost = asset.AssetCost;
            OutForRepairDate = asset.OutForRepairDate;
            BackFromRepairDate = asset.BackFromRepairDate;
            RetiredDate = asset.RetiredDate;
            SurplusDate = asset.SurplusDate;
            SaleProceeds = asset.SaleProceeds;
            Photopath = asset.Photopath;
            Type = asset.Type;
            if (Vehicle == null)
                Vehicle = new Vehicle();

            Vehicle.Copy(asset.Vehicle);

            LocationId = asset.LocationId;
            Location.Copy(asset.Location);

            AssignedTo = asset.AssignedTo;
        }
    }
}