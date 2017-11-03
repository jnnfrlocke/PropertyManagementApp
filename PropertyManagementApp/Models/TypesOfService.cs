using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class TypesOfService
    {
        [Key]
        public int Id { get; set; }

        public string Landscaping { get; set; }

        [Display(Name ="Snow Removal")]
        public string SnowRemoval { get; set; }

        public string Pavement { get; set; }

        public string Exterior { get; set; }

        public string Plumbing { get; set; }

        public string Electrical { get; set; }

        public string Appliances { get; set; }

        public string Painting { get; set; }

        public string General { get; set; }

        public string HVAC { get; set; }

        public string Roofing { get; set; }

        public string Windows { get; set; }

        public string Cleaning { get; set; }

        public string Carpet { get; set; }

        [Display(Name ="Drywall and Insulation")]
        public string DrywallInsulation { get; set; }

        public string Doors { get; set; }

    }
}