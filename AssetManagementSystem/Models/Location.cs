using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssetManagementSystem.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Department { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Phone { get; set; }

        public void Copy(Location location)
        {
            if (location == null)
                return;

            Id = location.Id;
            Name = location.Name;
            Department = location.Department;
            Address = location.Address;
            City = location.City;
            State = location.State;
            Phone = location.Phone;
        }
    }
}