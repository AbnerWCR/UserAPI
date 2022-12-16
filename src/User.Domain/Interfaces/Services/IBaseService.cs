using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.Domain.Interfaces
{
    public interface IBaseService<TDto> where TDto : class
    {
        Task<TDto> Create(TDto obj);

        Task<TDto> Update(TDto obj);

        Task Delete(Guid id);

        Task<IList<TDto>> Get();

        Task<TDto> GetById(Guid id);
    }
}
