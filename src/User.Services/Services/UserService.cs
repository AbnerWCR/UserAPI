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
    public class UserService : BaseService<UserDTO, Entity.User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
            : base(userRepository, mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public override async Task<UserDTO> Create(UserDTO userDto)
        {          
            try
            {
                var user = _mapper.Map<Entity.User>(userDto);
                user.Validate();

                var userExists = await UserExists(user.Email.Address);

                if (userExists)
                    throw new DomainException("user already exists.");

                user.Role.DefaultRole();
                user = await _userRepository.CreateAsync(user);

                user.Password.AddKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                user.Password.CreatePasswordHash(user.Id);

                user = await _userRepository.UpdatePasswordAsync(user);

                userDto = _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDto;
        }

        public override async Task<UserDTO> Update(UserDTO userDto)
        {
            try
            {
                var userRepo = await GetById(userDto.Id);

                if (userRepo == null)
                    throw new DomainException("user not found.");

                var user = _mapper.Map<Entity.User>(userRepo);
                user.Name.ChangeFirstName(userDto.FirstName);
                user.Name.ChangeLastName(userDto.LastName);
                user.Email.ChangeAddress(userDto.Email);

                var userUpdated = await _userRepository.UpdateAsync(user);

                userDto = _mapper.Map<UserDTO>(userUpdated);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDto;
        }

        public async Task<UserDTO> UpdatePassword(UserDTO userDto)
        {
            try
            {
                var userExists = await GetByEmail(userDto.Email);

                if (userExists == null)
                    throw new DomainException("user not found.");

                userExists.Password = userDto.Password;
                var user = _mapper.Map<Entity.User>(userExists);
                user.Password.AddKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                user.Password.CreatePasswordHash(user.Id);

                var userUpdated = await _userRepository.UpdatePasswordAsync(user);

                userDto = _mapper.Map<UserDTO>(userUpdated);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDto;
        }

        public async Task<UserDTO> UpdateRole(UserDTO userDto)
        {
            try
            {
                var userExists = await GetByEmail(userDto.Email);

                if (userExists == null)
                    throw new DomainException("user not found.");

                var user = _mapper.Map<Entity.User>(userExists);
                user.Role.ChangeRole();

                await _userRepository.UpdateRoleAsync(user);                
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDto;
        }

        public override async Task Delete(Guid id)
        {
            try
            {
                if (id == null)
                    throw new DomainException("invalid field.");

                await _userRepository.RemoveAsync(id);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }
        }

        public override async Task<UserDTO> GetById(Guid id)
        {
            var userDto = new UserDTO();

            try
            {
                if (id == null)
                    throw new DomainException("invalid field.");

                var user = await _userRepository.GetAsync(id);

                userDto = _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDto;
        }

        public override async Task<IList<UserDTO>> Get()
        {
            IList<UserDTO> userDTOs = new List<UserDTO>();

            try
            {
                var users = await _userRepository.GetAllAsync();

                userDTOs =  _mapper.Map<IList<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDTOs;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            var userDto = new UserDTO();

            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new DomainException("invalid field.");

                var user = await _userRepository.GetByEmail(email);

                userDto = _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                await SaveError(ex);
            }

            return userDto;
        }

        private async Task<bool> UserExists(string email)
        {
            var user = await _userRepository.GetByEmail(email);

            return user != null;
        }

        
    }
}
