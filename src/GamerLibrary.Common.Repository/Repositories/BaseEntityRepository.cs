using GamerLibrary.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerLibrary.Common.Repository
{
    /// <summary>
    /// Generic repository implementation
    /// </summary>
    /// <typeparam name="TBaseEntity">Entity type</typeparam>
    public class BaseEntityRepository<TBaseEntity> : IBaseEntityRepository<TBaseEntity>
        where TBaseEntity: BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TBaseEntity> _dbSet;

        public BaseEntityRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TBaseEntity>();
        }

        protected virtual DbContext DbContext => _dbContext;

        /// <summary>
        /// Detaches the entity from the DbContext's change tracker.
        /// </summary>
        public void Detach(TBaseEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TBaseEntity>> ReadAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
