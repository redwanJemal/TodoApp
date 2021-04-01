using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Business
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> ReadAsync(int id, bool tracking = true);

        Task<IReadOnlyList<TEntity>> ListAsync();
        Task<TEntity> UpdateAsync(int id, TEntity updateEntity);

        Task DeleteAsync(int id);
    }
}
