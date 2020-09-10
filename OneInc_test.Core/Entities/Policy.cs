using OneInc_test.Core.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneInc_test.Core.Entities
{
    public enum PolicyType { 
        Home,Car,Life
    }

    public enum PolicyState
    {
        Pending, Active, Expired
    }
    public class Policy : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BirthDate { get; set; }
        public string NameOwner { get; set; }
        public string SurnameOwner { get; set; }
        public string ObjectName { get; set; }
        public PolicyType ObjectType { get; set; }
        public string PolicyNumber => MonthCreated + "-" + Id;
        public DateTime UpdateDate { get; set; }
        public int MonthCreated { get; set; }

    }
}
