using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, IBaseEntity
    {

        protected WDSContext _wdsContext;

        public BaseService(WDSContext wdsContext)
        {
            _wdsContext = wdsContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _wdsContext.Set<TEntity>().AddAsync(entity);
            await _wdsContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> ReadAsync(int id, bool tracking = true)
        {
            var query = _wdsContext.Set<TEntity>().AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity updateEntity)
        {
            // Check that the record exists.
            var entity = await ReadAsync(id);

            if (entity == null)
            {
                throw new Exception("Unable to find record with id '" + id + "'.");
            }

            // Update changes if any of the properties have been modified.
            _wdsContext.Entry(entity).CurrentValues.SetValues(updateEntity);
            _wdsContext.Entry(entity).State = EntityState.Modified;

            if (_wdsContext.Entry(entity).Properties.Any(property => property.IsModified))
            {
                await _wdsContext.SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task DeleteAsync(int id)
        {
            // Check that the record exists.
            var entity = await ReadAsync(id);

            if (entity == null)
            {
                throw new Exception("Unable to find record with id '" + id + "'.");
            }

            // Set for Deletion
            _wdsContext.Entry(entity).State = EntityState.Deleted;

            // Save changes to the Db Context.
            await _wdsContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync()
        {
            var result = await _wdsContext.Set<TEntity>().ToListAsync();

            return result;
        }
    }
}
