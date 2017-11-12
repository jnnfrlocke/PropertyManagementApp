using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class Vacancies
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        [Display(Name = "Street Name")]
        public string StreetName { get; set; }

        public string Unit { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}