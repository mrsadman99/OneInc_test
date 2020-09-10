using OneInc_test.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneInc_test.Core.Repositories
{
    public interface IRepository<TEntity>:IDisposable
        where TEntity:BaseEntity
    {
        Task<List<TEntity>> GetListAsync();
        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> GetByCondition
            (Expression<Func<TEntity, bool>> expression);


        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Add(TEntity entity);

    }
}
