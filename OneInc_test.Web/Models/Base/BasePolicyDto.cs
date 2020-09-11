using OneInc_test.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OneInc_test.Web.Models.Base
{

    [DataContract]
    public class BasePolicyDto : IPolicyDto
    {
        protected DateTime _startDate;
        protected DateTime _endDate;
        protected DateTime _birthDate;


        


        [DataMember]
        [Display(Name = "Owner name")]
        [Required(ErrorMessage = "Owner name is required")]
        public string NameOwner { get; set; }

        [DataMember]
        [Display(Name = "Owner surname")]
        [Required(ErrorMessage = "Owner surname is required")]
        public string SurnameOwner { get; set; }

        [DataMember]
        [Display(Name = "Object name")]
        [Required(ErrorMessage = "Object name is required")]
        public string ObjectName { get; set; }

        [DataMember]
        [Display(Name = "Object type")]
        public PolicyType ObjectType { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last update")]
        public DateTime UpdateDate
        {
            get ;
            protected set ;
        }

        [Display(Name = "Policy state")]
        public PolicyState PolicyState
        {
            get {
                var now = DateTime.Now;
                if (_startDate > now)
                    return PolicyState.Pending;
                else if (_endDate > now)
                    return PolicyState.Active;
                return PolicyState.Expired;
            }
        }
    }
}