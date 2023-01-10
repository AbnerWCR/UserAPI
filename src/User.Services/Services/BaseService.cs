using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Domain.DTOs;
using User.Domain.Entities;
using User.Domain.Interfaces;

namespace User.Services.Services
{
    public class BaseService<TDto, TEntity> : IBaseService<TDto, TEntity> 
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public virtual async Task<TDto> Create(TDto obj)
        {
            if (obj == null)
                throw new Exception("invalid object");

            var entity = _mapper.Map<TEntity>(obj);

            var created = await _baseRepository.CreateAsync(entity);

            return _mapper.Map<TDto>(created);
        }

        public virtual async Task<TDto> Update(TDto obj)
        {
            if (obj == null)
                throw new Exception("invalid object");

            var entity = _mapper.Map<TEntity>(obj);

            var updated = await _baseRepository.UpdateAsync(entity);

            return _mapper.Map<TDto>(updated);
        }

        public async Task Delete(Guid id)
        {
            if (id == null)
                throw new Exception("invalid field");

            await _baseRepository.RemoveAsync(id);
        }

        public async Task<IList<TDto>> Get()
        {
            var entities = await _baseRepository.GetAllAsync();

            return _mapper.Map<IList<TDto>>(entities);
        }

        public async Task<TDto> GetById(Guid id)
        {
            if (id == null)
                throw new Exception("invalid field");

            var entity = await _baseRepository.GetAsync(id);

            return _mapper.Map<TDto>(entity);
        }

       
    }
}
