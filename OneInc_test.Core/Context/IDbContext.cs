using OneInc_test.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc_test.Core.Context
{
    public interface IDbContext:IDisposable
    {
        //?
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        void UpdateEntity<TEntity>(TEntity entity)
            where TEntity : BaseEntity;
        
        void DeleteEntity<TEntity>(TEntity entity)
            where TEntity : BaseEntity;

        void AddEntity<TEntity>(TEntity entity)
            where TEntity : BaseEntity;

        Task<int> SaveAsync();
    }
}
