using Chat.Repository.Core.Repositories;
using Chat.Repository.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Repository.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Declaration & Construstion & Dispose
        private SqlDbContext Context { get; set; }
        private DbSet<TEntity> _entities;
        private bool _isDisposed;

        public Repository(SqlDbContext context)
        {
            _isDisposed = false;
            Context = context;
        }

        public virtual DbSet<TEntity> Entities
        {
            get
            {
                return _entities ?? (_entities = Context.Set<TEntity>());
            }
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }
        #endregion Declaration & Construstion & Dispose



        #region Add
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity is empty!");
            }
            await Entities.AddAsync(entity);
            return entity;
        }
        #endregion Add


        #region Update
        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity is empty!");
            }
            Entities.Update(entity);
            return entity;
        }
        #endregion Update


        #region Remove
        public virtual TEntity Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Entity is empty!");
            Entities.Remove(entity);
            return entity;
        }
        #endregion Remove


        #region GetAll
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }
        #endregion GetAll


        #region Get
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }
        #endregion Get


        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
