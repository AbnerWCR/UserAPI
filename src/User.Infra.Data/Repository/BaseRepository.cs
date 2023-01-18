using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.Domain.Interfaces;
using User.Infra.Data.Context;

namespace User.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity : BaseEntity
    {
        private readonly UserContext _userContext;

        public BaseRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity obj)
        {
            _userContext.Add(obj);
            await _userContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            _userContext.Attach(obj);
            _userContext.Entry(obj).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();

            return obj;
        }

        public virtual async Task RemoveAsync(Guid id)
        {
            var obj = await GetAsync(id);

            if (obj != null)
            {
                _userContext.Remove(obj);
                await _userContext.SaveChangesAsync();
            }
        }

        public virtual async Task<IList<TEntity>> GetAllAsync()
        {
            return await _userContext.Set<TEntity>()
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            var obj = await _userContext.Set<TEntity>()
                                        .AsNoTracking()
                                        .Where(x => x.Id == id)
                                        .ToListAsync();

            return obj.FirstOrDefault();
        }
    }
}
