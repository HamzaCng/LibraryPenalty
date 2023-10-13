using Penalty.Api.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseModel
    {
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetList();
        /// <summary>
        /// Create new item
        /// </summary>
        /// <param name="t">Entity entry</param>
        Task Create(TEntity entity);
        /// <summary>
        /// Delete item (Soft)
        /// </summary>
        /// <param name="t">Entity entry</param>
        Task Delete(int id);
        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="t">Entity entry</param>
        Task Update(TEntity entity);
        /// <summary>
        /// Get by id item
        /// </summary>
        /// <param name="id">Item id entry</param>
        /// <returns></returns>
        Task<TEntity> GetById(int id);
    }
}
