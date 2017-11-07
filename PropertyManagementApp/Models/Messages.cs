using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManagementApp.Models
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }

        public string Resident { get; set; }

        [Display(Name ="Building Name")]
        public string BuildingName { get; set; }

        public string Unit { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        [Display(Name ="Recipient's Unit")]
        public string RecipientsUnit { get; set; }
    }
}