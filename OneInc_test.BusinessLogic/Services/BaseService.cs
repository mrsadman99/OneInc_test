using OneInc_test.Core.Context;
using OneInc_test.Core.Entities.Base;
using OneInc_test.Core.Repositories;
using OneInc_test.Core.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OneInc_test.BusinessLogic.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _rep;
        private readonly IDbContext _context;
        protected IQueryable<TEntity> _conditionQuery;


        private bool _disposed;
        protected BaseService(IRepository<TEntity> rep,IDbContext context){
            _context = context;
            _rep = rep;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            _rep.Add(entity);
            return await _context.SaveAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _rep.Delete(entity);
            await _context.SaveAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            _rep.Update(entity);
            await _context.SaveAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _rep.GetByIdAsync(id);
        }

        public async Task<List<TEntity>> GetListAsync()
        {
            if (_conditionQuery != null)
            {
                var result = await _conditionQuery.ToListAsync();
                _conditionQuery = null;
                return result;
            }
            else 
                return await _rep.GetListAsync();
        }

        protected void AttachCondition(Expression<Func<TEntity, bool>> expression)
        {
            if (_conditionQuery == null)
                _conditionQuery = _rep.GetByCondition(expression);
            else
                _conditionQuery = _conditionQuery.Where(expression);
        }

    }
}
