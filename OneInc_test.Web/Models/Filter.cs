using OneInc_test.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneInc_test.Web.Models
{
    public class Filter
    {
        [Display(Name = "Updated policies after date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? updateDate { get; set; }
        [Display(Name = "Owner name")]
        public string name { get; set; }
        [Display(Name = "Owner surname")]
        public string surname { get; set; }
        [Display(Name = "Policy state")]
        public PolicyState? state { get; set; }
        [Display(Name = "Object name")]
        public string objectName { get; set; }
        [Display(Name = "Owners information")]
        public bool nameSelected { get; set; }
    }
}