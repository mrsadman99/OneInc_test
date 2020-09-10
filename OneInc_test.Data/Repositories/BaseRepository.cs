using OneInc_test.Core.Context;
using OneInc_test.Core.Entities.Base;
using OneInc_test.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneInc_test.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : 
        IRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        private readonly IDbSet<TEntity> _entitySet;
        private bool _disposed;

        public BaseRepository(IDbContext context)
        {
            _context = context;
            _entitySet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _context.AddEntity(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.DeleteEntity(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _context.UpdateEntity(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (! _disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _entitySet.Where(expression);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entitySet.FirstOrDefaultAsync(e=>e.Id==id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            return await _entitySet.ToListAsync();
        }

        
    }
}
