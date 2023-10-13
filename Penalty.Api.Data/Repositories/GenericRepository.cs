using Microsoft.EntityFrameworkCore;
using Penalty.Api.Core.Models.Base;
using Penalty.Api.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty.Api.Data.Repositories
{
    /// <summary>
    /// Base generic repository
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity</typeparam>   
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        #region Fields
        private readonly PenaltyDbContext _dbContext;
        #endregion

        #region Ctor
        public GenericRepository(PenaltyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Methods
        public async Task Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id != 0)
            {
                var res = await GetById(id);
                res.Deleted = true;
                _dbContext.Set<TEntity>().Update(res);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetById(int id)
        {
            if (id == 0) 
                return null;

            return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TEntity> GetList()
        {        
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
