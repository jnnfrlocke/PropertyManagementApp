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
    }
}