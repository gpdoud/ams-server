using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class Vehicle
    {
        [Key, ForeignKey("Asset")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        //[Key]
        [Required]
        public string VIN { get; set; }

        [Required]
        public string License { get; set; }

        public bool HasLights { get; set; }

        public void Copy(Vehicle vehicle)
        {
            if (vehicle == null)
                return;
            //Id = vehicle.Id;
            AssetId = vehicle.AssetId;
          
            if (this.Asset != null && vehicle.Asset != null)
                this.Asset.Copy(vehicle.Asset);
          
            Make = vehicle.Make;
            Model = vehicle.Model;
            VIN = vehicle.VIN;
            License = vehicle.License;
            HasLights = vehicle.HasLights;
        }
    }
}