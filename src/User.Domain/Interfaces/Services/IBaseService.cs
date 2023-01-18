using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Domain.DTOs;
using User.Domain.Entities;

namespace User.Domain.Interfaces
{
    public interface IBaseService<TDto, TEntity> 
        where TDto : BaseDTO
        where TEntity : BaseEntity
    {
        Task<TDto> Create(TDto obj);

        Task<TDto> Update(TDto obj);

        Task Delete(Guid id);

        Task<IList<TDto>> Get();

        Task<TDto> GetById(Guid id);

        void ReturnError(string ex);
    }
}
