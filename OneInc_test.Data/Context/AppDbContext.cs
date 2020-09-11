using OneInc_test.Core.Context;
using OneInc_test.Core.Entities;
using OneInc_test.Core.Entities.Base;
using OneInc_test.Data.Configurations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace OneInc_test.Data.Context
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext():base("OneInc_test") {
        }

        public virtual IDbSet<Policy> Policy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PolicyConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void UpdateEntity<TEntity>(TEntity entity)
        where TEntity:BaseEntity
        {
            var entityEntry = GetDbEntityEntry(entity);
            entityEntry.State = EntityState.Modified;
        }

        public void DeleteEntity<TEntity>(TEntity entity)
        where TEntity : BaseEntity
        {
            var entityEntry = GetDbEntityEntry(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public void AddEntity<TEntity>(TEntity entity)
        where TEntity : BaseEntity
        {
            var entityEntry = GetDbEntityEntry(entity);
            entityEntry.State = EntityState.Added;
        }

        private DbEntityEntry GetDbEntityEntry<TEntity>(TEntity entity) 
            where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }

        public async Task<int> SaveAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
