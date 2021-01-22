
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Repository.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Add
        Task<TEntity> AddAsync(TEntity entity);
        #endregion Add

        #region Update
        TEntity Update(TEntity entity);
        #endregion Update

        #region Remove
        TEntity Remove(TEntity entity);
        #endregion Remove


        #region GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion GetAll


        #region Get
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion Get

        Task<int> CommitAsync();
    }
}
