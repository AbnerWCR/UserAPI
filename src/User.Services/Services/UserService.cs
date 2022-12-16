using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Domain.Interfaces;
using User.Domain.Interfaces.Services;
using User.Infra.CrossCutting.Exceptions;
using User.Infra.CrossCutting.Helpers;
using User.Services.DTOs;
using Entity = User.Domain.Entities;

namespace User.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDto)
        {
            var user = _mapper.Map<Entity.User>(userDto);
            user.Validate();

            var userExists = await UserExists(user.Email);

            if (userExists)
                throw new DomainException("user already exists.");

            var password = new ConvertPassword().CreatePasswordHash(user.Password);
            user.ChangePassword(password);

            var userCreated = await _userRepository.CreateAsync(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDto)
        {
            var user = _mapper.Map<Entity.User>(userDto);
            user.Validate();

            var userExists = await UserExists(user.Email);

            if (!userExists)
                throw new DomainException("user not found.");

            var userUpdated = await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task Delete(Guid id)
        {
            if (id == null)
                throw new DomainException("invalid field.");

            await _userRepository.RemoveAsync(id);
        }

        public async Task<UserDTO> GetById(Guid id)
        {
            if (id == null)
                throw new DomainException("invalid field.");

            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IList<UserDTO>> Get()
        {

            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IList<UserDTO>>(users);
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new DomainException("invalid field.");

            var user = await _userRepository.GetByEmail(email);

            return _mapper.Map<UserDTO>(user);
        }

        private async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return user != null;
        }

        
    }
}
