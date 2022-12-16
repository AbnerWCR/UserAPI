using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Domain.Entities;

namespace User.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity obj);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task RemoveAsync(Guid id);
        Task<IList<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid id);
    }
}
