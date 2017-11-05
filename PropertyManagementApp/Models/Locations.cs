using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class Locations
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name ="Street Number")]
        public string StreetNumber { get; set; }

        [Display(Name ="Street Name")]
        public string StreetName { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name ="Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name ="Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name ="Latitude")]
        public double Lat { get; set; }

        [Display(Name ="Longitude")]
        public double Long { get; set; }
    }
}