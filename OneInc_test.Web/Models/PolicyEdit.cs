using OneInc_test.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneInc_test.Web.Models
{
    public class PolicyEdit
    {
        public int Id { get; set; }
        public DateTime UpdateDate => DateTime.Now;
        public PolicyType ObjectType { get; set; }
        public string ObjectName { get; set; }
        public string NameOwner { get; set; }
        public string SurnameOwner { get; set; }

        public PolicyDtoCreated Convert(PolicyDtoCreated policy)
        {
            return new PolicyDtoCreated(Id,
                policy.StartDate,
                policy.EndDate,
                policy.BirthDate,
                policy.PolicyNumber,
                UpdateDate)
            {
                NameOwner = NameOwner,
                SurnameOwner = SurnameOwner,
                ObjectType = ObjectType,
                ObjectName = ObjectName
            };
        }

    }
}