using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class Resident
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name ="Name of Bulding")]
        public string Location { get; set; }

        public string Unit { get; set; }

        [EmailAddress]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name ="Rent in US Dollars")]
        public int Rent { get; set; }

        [Display(Name = "Payment in US Dollars")]
        public int Payment { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}