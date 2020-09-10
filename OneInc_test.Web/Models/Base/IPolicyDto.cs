using OneInc_test.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc_test.Web.Models.Base
{
    interface IPolicyDto
    {
        string NameOwner { get; set; }
        string SurnameOwner { get; set; }
        string ObjectName { get; set; }
        PolicyType ObjectType { get; set; }
    }
}
