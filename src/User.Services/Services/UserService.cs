using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Interfaces;
using User.Domain.Interfaces.Services;
using User.Infra.CrossCutting.Exceptions;
using User.Services.DTOs;
using Entity = User.Domain.Entities;

namespace User.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<UserDTO> Create(UserDTO userDto)
        {
            var user = _mapper.Map<Entity.User>(userDto);
            user.Validate();

            var userExists = await UserExists(user.Email.Address);

            if (userExists)
                throw new DomainException("user already exists.");

            user = await _userRepository.CreateAsync(user);

            user.Password.AddKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            user.Password.CreatePasswordHash(user.Id);

            user = await _userRepository.UpdatePasswordAsync(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Update(UserDTO userDto)
        {
            var userRepo = await GetById(userDto.Id);

            if (userRepo == null)
                throw new DomainException("user not found.");

            var user = _mapper.Map<Entity.User>(userRepo);
            user.Name.ChangeFirstName(userDto.FirstName);
            user.Name.ChangeLastName(userDto.LastName);
            user.Email.ChangeAddress(userDto.Email);

            var userUpdated = await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDTO>(userUpdated);
        }

        public async Task<UserDTO> UpdatePassword(UserDTO userDto)
        {
            var userExists = await GetByEmail(userDto.Email);

            if (userExists == null)
                throw new DomainException("user not found.");

            var user = _mapper.Map<Entity.User>(userExists);
            user.Password.AddKey(Encoding.UTF8.GetBytes(_configuration["Key"]));
            user.Password.CreatePasswordHash(user.Id);
        
            var userUpdated = await _userRepository.UpdatePasswordAsync(user);

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
