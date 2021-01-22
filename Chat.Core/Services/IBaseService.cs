using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chat.Core.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        #region Add
        Task<TEntity> AddAsync(TEntity entity);
        #endregion Add

        #region Remove
        Task<TEntity> Remove(TEntity entity);
        #endregion Remove


        #region GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion GetAll


        #region Get
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion Get
    }
}
