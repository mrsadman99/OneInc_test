using OneInc_test.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneInc_test.Core.Services
{
    public interface IService<TEntity>:IDisposable
        where TEntity: BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> GetListAsync();
        Task<TEntity> GetByIdAsync(int id);

    }
}
