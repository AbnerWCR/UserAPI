using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Domain.Entities;
using User.Domain.Interfaces;

namespace User.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<TEntity> Create(TEntity obj)
        {
            if (obj == null)
                throw new Exception("invalid object");

            return await _baseRepository.CreateAsync(obj);
        }

        public virtual async Task<TEntity> Update(TEntity obj)
        {
            if (obj == null)
                throw new Exception("invalid object");

            return await _baseRepository.UpdateAsync(obj);
        }

        public async Task Delete(Guid id)
        {
            if (id == null)
                throw new Exception("invalid field");

            await _baseRepository.RemoveAsync(id);
        }

        public async Task<IList<TEntity>> Get()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            if (id == null)
                throw new Exception("invalid field");

            return await _baseRepository.GetAsync(id);
        }

       
    }
}
