﻿using System.Threading.Tasks;
using User.Services.DTOs;

namespace User.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<UserDTO, Entities.User>
    {
        Task<UserDTO> UpdatePassword(UserDTO userDto);
        Task<UserDTO> UpdateRole(UserDTO userDto);
        Task<UserDTO> GetByEmail(string email);
    }
}
