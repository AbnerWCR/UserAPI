using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using User.API.ViewModels;
using User.Domain.DTOs;
using User.Domain.Entities;
using User.Domain.Interfaces;
using User.Domain.Interfaces.Services;
using User.Domain.Roles;
using User.Infra.CrossCutting.Messages;
using User.Services.DTOs;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IBaseService<ErrorDTO, Error> errorService, IUserService userService, IMapper mapper)
            : base(errorService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel createUserVm)
        {
            try
            {
                var user = _mapper.Map<UserDTO>(createUserVm);

                var userCreated = await _userService.Create(user);

                var uri = new Uri($"api/user/{userCreated.Id}", UriKind.RelativeOrAbsolute);

                return ResultCreated(uri, Messages.UserCreated, userCreated);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel updateUserVm)
        {
            try
            {
                var user = _mapper.Map<UserDTO>(updateUserVm);

                var result = await _userService.Update(user);
                return ResultOk(Messages.UserUpdated, result);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpPut("update-password")]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordViewModel updatePwVm)
        {
            try
            {
                var user = _mapper.Map<UserDTO>(updatePwVm);

                var result = await _userService.UpdatePassword(user);
                return ResultOk(Messages.UserUpdated, result);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpPut("update-role")]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateUserRoleViewModel updateRoleVm)
        {
            try
            {
                var user = _mapper.Map<UserDTO>(updateRoleVm);

                var result = await _userService.UpdateRole(user);
                return ResultOk(Messages.UserUpdated, result);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (id == null)
                    return ResultNotFound(Messages.UserNotFound);

                await _userService.Delete(id);

                return ResultOk(Messages.UserDeleted, null);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.Get();

                return ResultOk(string.Empty, result);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.ALL_ROLES)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _userService.GetById(id);

                return ResultOk(string.Empty, result);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }

        [HttpGet("{email}/by-email")]
        [Authorize(Roles = UserRoles.ALL_ROLES)]
        public async Task<IActionResult> Get(string email)
        {
            try
            {
                var result = await _userService.GetByEmail(email);

                if (result == null)
                    return ResultNotFound(Messages.UserNotFound);

                return ResultOk(string.Empty, result);
            }
            catch (Exception ex)
            {
                var errorDto = new ErrorDTO(ex.Message);
                return await SaveError(errorDto);
            }
        }
    }
}
