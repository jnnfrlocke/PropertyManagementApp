using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class PreferredServiceProviders
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Type of Service")]
        public string Type { get; set; }

        [Display(Name ="Pre-Approved")]
        public bool PreApproved { get; set; }

        [Required]
        public string Company { get; set; }

        public string Contact { get; set; }

        [Required]
        [Phone]
        [Display(Name ="Office Phone Number")]
        public int OfficePhone { get; set; }

        [Phone]
        [Display(Name ="Mobile Phone Number")]
        public int? MobilePhone { get; set; }

        [EmailAddress]
        [Display(Name ="Email Address")]
        public string Email { get; set; }

        [Display(Name ="Street Address")]
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }

        [Url]
        public string Website { get; set; }
    }
}