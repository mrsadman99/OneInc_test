using OneInc_test.Core.Context;
using OneInc_test.Core.Entities;
using OneInc_test.Core.Repositories;
using System;
using System.Linq;

namespace OneInc_test.BusinessLogic.Services
{
    public class PolicyService : BaseService<Policy>
    {
        public PolicyService(IRepository<Policy> rep, IDbContext context)
            : base(rep, context)
        {

        }
        public void GetByName(string Name)
        {
            AttachCondition(e =>
                e.NameOwner.Equals(Name));
        }

        public void GetBySurname(string Surname)
        {
            AttachCondition(e =>
                e.SurnameOwner.Equals(Surname));
        }

        public void GetUpdatedAfterDate(DateTime date)
        {
            AttachCondition(e => e.UpdateDate > date);
        }

        public void GetByObjectName(string objectName)
        {
            AttachCondition(e => e.ObjectName.Contains(objectName));
        }

        
        public void GetByState(PolicyState state)
        {
            var now = DateTime.Now;
            switch (state)
            {
                case PolicyState.Pending:
                    AttachCondition(e => e.StartDate>now);
                    break;
                case PolicyState.Active:
                    AttachCondition(e => e.EndDate>= now && e.StartDate<=now);
                    break;
                case PolicyState.Expired:
                    AttachCondition(e => e.EndDate < now);
                    break;
                default:
                    throw new NotImplementedException("Cannot define policy state");
            }
        }
    }
}
