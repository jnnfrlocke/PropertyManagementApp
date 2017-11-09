using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class AvailableUnitInfoRequests
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name ="Building and Unit of Interest")]
        public string Subject { get; set; }

        [Display(Name ="Details")]
        public string Body { get; set; }
    }
}