using OneInc_test.Core.Context;
using OneInc_test.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc_test.Data.Repositories
{
    public class PolicyRepository : BaseRepository<Policy>
    {
        public PolicyRepository(IDbContext context)
           : base(context)
        {

        }
    }
}
