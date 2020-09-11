using OneInc_test.Web.Models.Base;
using OneInc_test.Web.Models.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;

namespace OneInc_test.Web.Models
{
    [DataContract]
    public class PolicyDtoCreate : BasePolicyDto
    {
        public PolicyDtoCreate()
        {
            var now= DateTime.Now; 
            UpdateDate = now;
            StartDate = now;
            BirthDate = now;
            EndDate = now;
        }


        [DataMember]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }
        [DataMember]
        [Display(Name = "End date")]
        [EndDate]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }
        [DataMember]
        [Display(Name = "Date of birth")]
        [DateOfBirth]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }
    }
}