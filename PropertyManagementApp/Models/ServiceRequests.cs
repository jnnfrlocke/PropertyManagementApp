using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PropertyManagementApp.Models
{
    public class ServiceRequests
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name ="Name of Building")]
        public string Location { get; set; }

        [Display(Name ="Type of Service")]
        public string TypeOfService { get; set; }

        public string Details { get; set; }

        public string Urgency { get; set; }

        [Display(Name = "Date Submitted")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public string DateSubmitted { get; set; }

        [Display(Name ="Contractor Used")]
        public string ContractorUsed { get; set; }

        [Display(Name ="Follow Up Needed")]
        public bool FollowUpNeeded { get; set; }

        public bool Completed { get; set; }

        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public string DateCompleted { get; set; }
    }
}