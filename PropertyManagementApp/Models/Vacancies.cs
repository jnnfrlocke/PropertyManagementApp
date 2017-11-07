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

        public string Unit { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}