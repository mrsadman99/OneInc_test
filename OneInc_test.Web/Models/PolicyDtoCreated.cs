using OneInc_test.Web.Models.Base;
using OneInc_test.Web.Models.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace OneInc_test.Web.Models
{
    [DataContract]
    public class PolicyDtoCreated : BasePolicyDto
    {
        public PolicyDtoCreated(int id,DateTime start, DateTime end, DateTime birthDate, string policyNum, DateTime updateTime)
        {
            Id = id;
            StartDate = start;
            EndDate = end;
            BirthDate = birthDate;
            PolicyNumber = policyNum;
            UpdateDate = updateTime;
        }
        [DataMember]
        public int Id { get; private set; }


        [DataMember]
        [Display(Name = "Policy number")]
        public string PolicyNumber
        {
            get;
            private set;
        }
        [DataMember]
        [Display(Name = "Start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate
        {
            get => _startDate;
            private set => _startDate = value;
        }

        [DataMember]
        [Display(Name = "End date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { 
            get => _endDate; 
            private set => _endDate = value; 
        }

        [DataMember]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate
        {
            get => _birthDate;
            private set => _birthDate = value;
        }

    }
}